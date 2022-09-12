using GameStore.DAL.Context;
using GameStore.Domain.DTO;
using GameStore.Domain.Entities;
using GameStore.Interfaces.Services;
using GameStore.Service.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Services.InSQL
{
    /// <summary>
    /// Сервис работы с сущностями Игра
    /// </summary>
    public class SqlGameService : IGameService
    {
        private readonly GameStoreDB _db;
        private readonly IPublisherService _publisherService;
        private readonly IGenreService _genreService;
        private readonly ILogger<SqlGameService> _logger;

        public SqlGameService(GameStoreDB gameStoreDB,
            IPublisherService publisherService,
            IGenreService genreService,
            ILogger<SqlGameService> logger)
        {
            _db = gameStoreDB;
            _publisherService = publisherService;
            _genreService = genreService;
            _logger = logger;
        }

        public int Add(GameDTO gameDTO)
        {
            int id = -1;    //В случае ошибки при создании, вернется несуществующий id

            try
            {
                var game = _db.Games.Add(GameDtoToEntityHelper(gameDTO));
                _db.SaveChanges();
                id = game.Entity.Id;
            }
            catch (Exception)
            {
                _logger.LogError("Не удалось создать игру {0}", gameDTO.Name);
            }

            return id;
        }


        public bool Delete(int id)
        {
            var game = _db.Games.FirstOrDefault(g => g.Id == id);
            try
            {
                //Удаляем игру в жанрах
                foreach (var item in _db.Genres.Where(g => g.Games.Contains(game)))
                {
                    item.Games.Remove(game);
                }

                //Удаляем игру
                _db.Games.Remove(game);

                _db.SaveChanges();
            }
            catch (Exception)
            {
                _logger.LogError("Не удалось удалить игру Id:{0}", id);
                return false;
            }

            return true;
        }

        public IEnumerable<GameDTO> Get() =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            Select(g => g.ToDTO());


        public GameDTO Get(int id) =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            FirstOrDefault(g => g.Id == id).
            ToDTO();


        public IEnumerable<GameDTO> GetByGenre(int id) =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            Where(g => g.Genres.First(c => c.Id == id) != null).
            Select(g => g.ToDTO());

        public IEnumerable<GameDTO> GetByGenre(string name) =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            Where(g => g.Genres.First(c => c.Name == name) != null).
            Select(g => g.ToDTO());


        public GameDTO GetByName(string name) =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            FirstOrDefault(g => g.Name == name).
            ToDTO();

        public bool Update(GameDTO gameUpdated)
        {
            //Изменяемая игра
            var item = _db.Games.
                Include(g => g.Publisher).
                Include(g => g.Genres).
                FirstOrDefault(g => g.Id == gameUpdated.Id) ??   //Пробуем найти игру по Id
                _db.Games.
                Include(g => g.Publisher).
                Include(g => g.Genres).
                FirstOrDefault(g => g.Name == gameUpdated.Name);    //Ищем игру по имени, если по Id ничего не найдено

            if (item is null)
            {
                _logger.LogError("Не удалось найти игру Id:{0} при обновлении", gameUpdated.Id);
                return false;
            }
            //Обновляем имя игры
            item.Name = gameUpdated.Name;
            _db.SaveChanges();

            # region Обновляем издателя игры
            try
            {
                Publisher publisher = null;
                //Если Id издателя на изменилось, но изменилось его название, то обновляем название издателя
                if (item.Publisher.Id == gameUpdated.Publisher.Id && item.Publisher.Name != gameUpdated.Publisher.Name)
                {
                    int id = _publisherService.Update(gameUpdated.Publisher).Id;
                    publisher = _db.Publishers.FirstOrDefault(p => p.Id == id);
                }
                //Если Id издателя изменился, то задаем игре существующего издателя по Id
                else if (item.Publisher.Id != gameUpdated.Publisher.Id)
                {
                    publisher = _db.Publishers.FirstOrDefault(p => p.Id == gameUpdated.Publisher.Id);
                }
                //Если издателя не нашли по Id, пробуем найти по имени
                else if(publisher is null)
                {
                    //Если издателя с таким именем не существует, то создаем нового
                    publisher = _db.Publishers.FirstOrDefault(p => p.Name == gameUpdated.Publisher.Name)??
                        new Publisher { Name= gameUpdated.Publisher.Name };
                }

                item.Publisher = publisher;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                _logger.LogError("Не удалось изменить издателя {0} при обновлении игры", gameUpdated.Publisher.Name);
                return false;
            }

            #endregion

            #region Обновляем жанр игры

            try
            {
                //Удаляем связь жанра с игрой
                foreach (var genre in item.Genres)
                {
                    genre.Games.Remove(item);
                }
                item.Genres.Clear();


                //Обновляем каждый жанр и заново добавляем связь с игрой
                foreach (var genre in gameUpdated.Genres)
                {
                    var currentGenreId = _genreService.Update(genre).Id;   //Обновляем жанр и сохраняем его Id
                    var currentGenre = _db.Genres.FirstOrDefault(g => g.Id == currentGenreId);

                    item.Genres.Add(currentGenre);
                    currentGenre.Games.Add(item);
                }
                _db.SaveChanges();
            }
            catch (Exception)
            {
                var genresName = String.Join(',', gameUpdated.Genres.Select(g => g.Name));
                _logger.LogError("Не удалось изменить жанр(ы) {0} при обновлении игры", genresName);
                return false;
            }

            #endregion

            return true;
        }

        private Game GameDtoToEntityHelper(GameDTO gameDTO)
        {
            Game game = new Game();
            game.Id = 0;
            game.Name = gameDTO.Name;

            game.Publisher = _db.Publishers.FirstOrDefault(p => p.Name == gameDTO.Publisher.Name) ??
                new Publisher { Name = gameDTO.Publisher.Name };
            foreach (var genreDto in gameDTO.Genres)
            {
                var genre = _db.Genres.FirstOrDefault(g => g.Name == genreDto.Name) ??
                    new Genre { Name = genreDto.Name };
                game.Genres.Add(genre);
                genre.Games.Add(game);
            }
            return game;
        }
    }
}
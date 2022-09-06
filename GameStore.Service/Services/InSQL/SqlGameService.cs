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
        private readonly IPublisherService _PublisherService;
        private readonly IGenreService _GenreService;
        private readonly ILogger<SqlGameService> _Logger;

        public SqlGameService(GameStoreDB GameStoreDB,
            IPublisherService PublisherService,
            IGenreService GenreService,
            ILogger<SqlGameService> Logger)
        {
            _db = GameStoreDB;
            _PublisherService = PublisherService;
            _GenreService = GenreService;
            _Logger = Logger;
        }
        public int Add(GameDTO Game)
        {
            int id = -1;    //В случае ошибки при создании, вернется несуществующий id
            GameDTO gameDto = Game;
            Game game = GameDtoToEntityHelper(gameDto);
            try
            {
                var gameEnity = _db.Games.Add(game);
                _db.SaveChanges();
                id = gameEnity.Entity.Id;
            }
            catch (Exception ex)
            {
                _Logger.LogError("Не удалось создать игру {0}", Game.Name);
            }

            return id;
        }


        public bool Delete(int Id)
        {
            var game = _db.Games.FirstOrDefault(g => g.Id == Id);
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
                _Logger.LogError("Не удалось удалить игру Id:{0}", Id);
                return false;
            }

            return true;
        }

        public IEnumerable<GameDTO> Get() =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            Select(g => g.ToDTO());


        public GameDTO Get(int Id) =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            FirstOrDefault(g => g.Id == Id).
            ToDTO();


        public IEnumerable<GameDTO> GetByGenre(int Id) =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            Where(g => g.Genres.First(c => c.Id == Id) != null).
            Select(g => g.ToDTO());

        public IEnumerable<GameDTO> GetByGenre(string Name) =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            Where(g => g.Genres.First(c => c.Name == Name) != null).
            Select(g => g.ToDTO());


        public GameDTO GetByName(string Name) =>
            _db.Games.
            Include(g => g.Publisher).
            Include(g => g.Genres).
            FirstOrDefault(g => g.Name == Name).
            ToDTO();

        public bool Update(GameDTO GameUpdated)
        {
            //Изменяемая игра
            var item = _db.Games.
                Include(g => g.Publisher).
                Include(g => g.Genres).
                FirstOrDefault(g => g.Id == GameUpdated.Id) ??   //Пробуем найти игру по Id
                _db.Games.
                Include(g => g.Publisher).
                Include(g => g.Genres).
                FirstOrDefault(g => g.Name == GameUpdated.Name);    //Ищем игру по имени, если по Id ничего не найдено

            if (item is null)
            {
                _Logger.LogError("Не удалось найти игру Id:{0} при обновлении", GameUpdated.Id);
                return false;
            }
            //Обновляем имя игры
            item.Name = GameUpdated.Name;
            _db.SaveChanges();

            # region Обновляем издателя игры
            try
            {
                Publisher publisher = null;
                //Если Id издателя на изменилось, но изменилось его название, то обновляем название издателя
                if (item.Publisher.Id == GameUpdated.Publisher.Id && item.Publisher.Name != GameUpdated.Publisher.Name)
                {
                    int id = _PublisherService.Update(GameUpdated.Publisher).Id;
                    publisher = _db.Publishers.FirstOrDefault(p => p.Id == id);
                }
                //Если Id издателя изменился, то задаем игре существующего издателя по Id
                else if (item.Publisher.Id != GameUpdated.Publisher.Id)
                {
                    publisher = _db.Publishers.FirstOrDefault(p => p.Id == GameUpdated.Publisher.Id);
                }
                //Если издателя не нашли по Id, пробуем найти по имени
                else if(publisher is null)
                {
                    //Если издателя с таким именем не существует, то создаем нового
                    publisher = _db.Publishers.FirstOrDefault(p => p.Name == GameUpdated.Publisher.Name)??
                        new Publisher { Name= GameUpdated.Publisher.Name };
                }

                item.Publisher = publisher;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                _Logger.LogError("Не удалось изменить издателя {0} при обновлении игры", GameUpdated.Publisher.Name);
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
                foreach (var genre in GameUpdated.Genres)
                {
                    var current_genreid = _GenreService.Update(genre).Id;   //Обновляем жанр и сохраняем его Id
                    var current_genre = _db.Genres.FirstOrDefault(g => g.Id == current_genreid);

                    item.Genres.Add(current_genre);
                    current_genre.Games.Add(item);
                }
                _db.SaveChanges();
            }
            catch (Exception)
            {
                var genres_name = String.Join(',', GameUpdated.Genres.Select(g => g.Name));
                _Logger.LogError("Не удалось изменить жанр(ы) {0} при обновлении игры", genres_name);
                return false;
            }

            #endregion

            return true;
        }

        private Game GameDtoToEntityHelper(GameDTO GameDTO)
        {
            Game game = new Game();
            game.Id = 0;
            game.Name = GameDTO.Name;

            game.Publisher = _db.Publishers.FirstOrDefault(p => p.Name == GameDTO.Publisher.Name) ??
                new Publisher { Name = GameDTO.Publisher.Name };
            foreach (var genreDto in GameDTO.Genres)
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
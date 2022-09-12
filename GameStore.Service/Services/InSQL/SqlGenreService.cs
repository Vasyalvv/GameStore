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
    public class SqlGenreService : IGenreService
    {
        private readonly GameStoreDB _db;
        private readonly ILogger<SqlGenreService> _logger;

        public SqlGenreService(GameStoreDB gameStoreDB, ILogger<SqlGenreService> logger)
        {
            _db = gameStoreDB;
            _logger = logger;
        }

        public int Add(GenreDTO genre)
        {
            int id = -1;    //В случае ошибки при создании, вернется несуществующий id
            try
            {
                genre.Id = 0;
                _db.Genres.Add(genre.FromDTO());
                _db.SaveChanges();
                id = _db.Genres.FirstOrDefault(g => g.Name == genre.Name).Id;
            }
            catch (Exception)
            {
                _logger.LogError("Не удалось создать жанр {0}", genre.Name);
            }
            return id;
        }

        public IEnumerable<GenreDTO> Add(IEnumerable<GenreDTO> genres)
        {
            List<GenreDTO> genresResult = new List<GenreDTO>();

            try
            {
                foreach (var item in genres)
                {
                    var id= Add(item);
                    //Добавляем созданные жанры в результат
                    genresResult.Add(_db.Genres.FirstOrDefault(g => g.Id == id).ToDTO());
                }
            }
            catch (Exception)
            {
                var genresName = String.Join(',', genres.Select(g => g.Name));
                _logger.LogError("Не удалось создать список жанров {0}", genresName);
            }
            return genresResult.AsEnumerable();
        }

        public bool Delete(int id)
        {
            var genre = _db.Genres.FirstOrDefault(p => p.Id == id);
            try
            {
                //Удаляем игровой жанр
                _db.Genres.Remove(genre);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                _logger.LogError("Не удалось удалить жанр Id:{0}", id);
                return false;
            }

            return true;
        }

        public IEnumerable<GenreDTO> Get() => _db.Genres
            .Include(g => g.Games).
            Select(g => g.ToDTO());

        public GenreDTO Get(int id) => _db.Genres
            .Include(g => g.Games).
            FirstOrDefault(g => g.Id == id).
            ToDTO();

        public GenreDTO GetByName(string name) => _db.Genres
            .Include(g => g.Games).
            FirstOrDefault(g => g.Name == name).
            ToDTO();

        public GenreDTO Update(GenreDTO genre)
        {
            GenreDTO result = null;
            int id = genre.Id;
            try
            {
                if (genre.Id == 0)  //Если Id==0 в DTO модели, то нужно создать новый игровой жанр
                    id = Add(genre);
                else
                {                       //Иначе, редактируем существующий игровой жанр
                    _db.Genres.
                        FirstOrDefault(g => g.Id == genre.Id).
                        Name = genre.Name;
                    _db.SaveChanges();
                }
                result = _db.Genres.FirstOrDefault(g => g.Id == id).ToDTO();
            }
            catch (Exception)
            {
                _logger.LogError("Не удалось обновить жанр {0}", genre.Name);
            }

            return result;
        }
    }
}

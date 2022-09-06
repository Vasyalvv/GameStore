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
        private readonly ILogger<SqlGenreService> _Logger;

        public SqlGenreService(GameStoreDB GameStoreDB, ILogger<SqlGenreService> Logger)
        {
            _db = GameStoreDB;
            _Logger = Logger;
        }
        public int Add(GenreDTO Genre)
        {
            int id = -1;    //В случае ошибки при создании, вернется несуществующий id
            try
            {
                Genre.Id = 0;
                _db.Genres.Add(Genre.FromDTO());
                _db.SaveChanges();
                id = _db.Genres.FirstOrDefault(g => g.Name == Genre.Name).Id;
            }
            catch (Exception)
            {
                _Logger.LogError("Не удалось создать жанр {0}", Genre.Name);
            }
            return id;
        }

        public IEnumerable<GenreDTO> Add(IEnumerable<GenreDTO> Genres)
        {
            List<GenreDTO> genres = new List<GenreDTO>();

            try
            {
                foreach (var item in Genres)
                {
                    var id= Add(item);
                    //Добавляем созданные жанры в результат
                    genres.Add(_db.Genres.FirstOrDefault(g => g.Id == id).ToDTO());
                }
            }
            catch (Exception)
            {
                var genres_name = String.Join(',', Genres.Select(g => g.Name));
                _Logger.LogError("Не удалось создать список жанров {0}", genres_name);
            }
            return genres.AsEnumerable();
        }

        public bool Delete(int Id)
        {
            var genre = _db.Genres.FirstOrDefault(p => p.Id == Id);
            try
            {
                //Удаляем игровой жанр
                _db.Genres.Remove(genre);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                _Logger.LogError("Не удалось удалить жанр Id:{0}", Id);
                return false;
            }

            return true;
        }

        public IEnumerable<GenreDTO> Get() => _db.Genres
            .Include(g => g.Games).
            Select(g => g.ToDTO());

        public GenreDTO Get(int Id) => _db.Genres
            .Include(g => g.Games).
            FirstOrDefault(g => g.Id == Id).
            ToDTO();

        public GenreDTO GetByName(string Name) => _db.Genres
            .Include(g => g.Games).
            FirstOrDefault(g => g.Name == Name).
            ToDTO();

        public GenreDTO Update(GenreDTO Genre)
        {
            GenreDTO result = null;
            int id = Genre.Id;
            try
            {
                if (Genre.Id == 0)  //Если Id==0 в DTO модели, то нужно создать новый игровой жанр
                    id = Add(Genre);
                else
                {                       //Иначе, редактируем существующий игровой жанр
                    _db.Genres.
                        FirstOrDefault(g => g.Id == Genre.Id).
                        Name = Genre.Name;
                    _db.SaveChanges();
                }
                result = _db.Genres.FirstOrDefault(g => g.Id == id).ToDTO();
            }
            catch (Exception ex)
            {
                _Logger.LogError("Не удалось обновить жанр {0}", Genre.Name);
            }

            return result;
        }
    }
}

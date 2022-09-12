using GameStore.Domain.DTO;
using GameStore.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.WebApi.Controllers
{
    /// <summary>
    /// API контроллер взаимодействия с сущностью Жанр
    /// </summary>
    [Route("api/genres")]
    [ApiController]
    public class GenreApiController : ControllerBase,IGenreService
    {
        private readonly IGenreService _genreService;

        public GenreApiController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Добавление нового игрового жанра
        /// </summary>
        /// <param name="genre">Игровой жанр</param>
        /// <returns>Идентификатор добавленного игрового жанра</returns>
        [HttpPost]
        public int Add(GenreDTO genre)
        {
            return _genreService.Add(genre);
        }

        /// <summary>
        /// Добавление списка новых игровых жанров
        /// </summary>
        /// <param name="genres">Список игровых жанров</param>
        /// <returns>Список созданных игровых жанров</returns>
        [HttpPost("list")]
        public IEnumerable<GenreDTO> Add(IEnumerable<GenreDTO> genres)
        {
            return _genreService.Add(genres);
        }

        /// <summary>
        /// Удаление игрового жанра
        /// </summary>
        /// <param name="id">Идентификатор игрового жанра</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _genreService.Delete(id);
        }

        /// <summary>
        /// Получение списка всех игровых жанров
        /// </summary>
        /// <returns>Список игровых жанров</returns>
        [HttpGet]
        public IEnumerable<GenreDTO> Get()
        {
            return _genreService.Get();
        }

        /// <summary>
        /// Получение игрового жарна по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор игрового жанра</param>
        /// <returns>Игровой жанр</returns>
        [HttpGet("{id}")]
        public GenreDTO Get(int id)
        {
            return _genreService.Get(id);
        }

        /// <summary>
        /// Получение игрового жарна по названию
        /// </summary>
        /// <param name="name">Название игрового жанра</param>
        /// <returns>Игровой жанр</returns>
        [HttpGet("genre")]
        public GenreDTO GetByName(string name)
        {
            return _genreService.GetByName(name);
        }

        /// <summary>
        /// Обновление информации об игровом жанре
        /// </summary>
        /// <param name="genre">Жанр</param>
        /// <returns>Обновленная запись игрового жанра</returns>
        [HttpPut]
        public GenreDTO Update(GenreDTO genre)
        {
            return _genreService.Update(genre);
        }
    }
}

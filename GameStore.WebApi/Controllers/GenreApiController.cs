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
        private readonly IGenreService _GenreService;

        public GenreApiController(IGenreService GenreService)
        {
            _GenreService = GenreService;
        }

        /// <summary>
        /// Добавление нового игрового жанра
        /// </summary>
        /// <param name="Genre">Игровой жанр</param>
        /// <returns>Идентификатор добавленного игрового жанра</returns>
        [HttpPost]
        public int Add(GenreDTO Genre)
        {
            return _GenreService.Add(Genre);
        }

        /// <summary>
        /// Добавление списка новых игровых жанров
        /// </summary>
        /// <param name="Genres">Список игровых жанров</param>
        /// <returns>Список созданных игровых жанров</returns>
        [HttpPost("list")]
        public IEnumerable<GenreDTO> Add(IEnumerable<GenreDTO> Genres)
        {
            return _GenreService.Add(Genres);
        }

        /// <summary>
        /// Удаление игрового жанра
        /// </summary>
        /// <param name="Id">Идентификатор игрового жанра</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return _GenreService.Delete(Id);
        }

        /// <summary>
        /// Получение списка всех игровых жанров
        /// </summary>
        /// <returns>Список игровых жанров</returns>
        [HttpGet]
        public IEnumerable<GenreDTO> Get()
        {
            return _GenreService.Get();
        }

        /// <summary>
        /// Получение игрового жарна по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор игрового жанра</param>
        /// <returns>Игровой жанр</returns>
        [HttpGet("{Id}")]
        public GenreDTO Get(int Id)
        {
            return _GenreService.Get(Id);
        }

        /// <summary>
        /// Получение игрового жарна по названию
        /// </summary>
        /// <param name="Name">Название игрового жанра</param>
        /// <returns>Игровой жанр</returns>
        [HttpGet("genre")]
        public GenreDTO GetByName(string Name)
        {
            return _GenreService.GetByName(Name);
        }

        /// <summary>
        /// Обновление информации об игровом жанре
        /// </summary>
        /// <param name="Genre">Жанр</param>
        /// <returns>Обновленная запись игрового жанра</returns>
        [HttpPut]
        public GenreDTO Update(GenreDTO Genre)
        {
            return _GenreService.Update(Genre);
        }
    }
}

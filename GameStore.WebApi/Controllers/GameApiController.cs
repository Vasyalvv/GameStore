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
    /// API контроллер взаимодействия с сущностью Игра
    /// </summary>
    [Route("api/game")]
    [ApiController]
    public class GameApiController : ControllerBase,IGameService
    {
        private readonly IGameService _GameService;

        public GameApiController(IGameService GameService)
        {
            _GameService = GameService;
        }

        /// <summary>
        /// Добавление новой игры
        /// </summary>
        /// <param name="Game">Игра</param>
        /// <returns>Идентификатор добавленной игры</returns>
        [HttpPost]
        public int Add(GameDTO Game)
        {
            return _GameService.Add(Game);
        }

        /// <summary>
        /// Удаление игры
        /// </summary>
        /// <param name="Id">Идентификатор игры</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("Id")]
        public bool Delete(int Id)
        {
            return _GameService.Delete(Id);
        }

        /// <summary>
        /// Получение списка всех игр
        /// </summary>
        /// <returns>Список игр</returns>
        [HttpGet]
        public IEnumerable<GameDTO> Get()
        {
            return _GameService.Get();
        }

        /// <summary>
        /// Получение игры по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор игры</param>
        /// <returns>Ирга</returns>
        [HttpGet("Id")]
        public GameDTO Get(int Id)
        {
            return _GameService.Get(Id);
        }

        /// <summary>
        /// Получение списка игр по жанру
        /// </summary>
        /// <param name="Id">Идентификатор жанра</param>
        /// <returns>Список игр</returns>
        [HttpGet("genre/{Id}")]
        public IEnumerable<GameDTO> GetByGenre(int Id)
        {
            return _GameService.GetByGenre(Id);
        }

        /// <summary>
        /// Получение списка игр по жанру
        /// </summary>
        /// <param name="Name">Название жанра</param>
        /// <returns>Список игр</returns>
        [HttpGet("genre/name/{Name}")]
        public IEnumerable<GameDTO> GetByGenre(string Name)
        {
            return _GameService.GetByGenre(Name);
        }

        /// <summary>
        /// Получение игры по названию
        /// </summary>
        /// <param name="Name">Название игры</param>
        /// <returns>Игра</returns>
        [HttpGet("name/{Name}")]
        public GameDTO GetByName(string Name)
        {
            return _GameService.GetByName(Name);
        }

        /// <summary>
        /// Обновление информации игры
        /// </summary>
        /// <param name="Game">Игра</param>
        /// <returns>Результат обновления</returns>
        [HttpPut]
        public bool Update(GameDTO Game)
        {
            return _GameService.Update(Game);
        }
    }
}

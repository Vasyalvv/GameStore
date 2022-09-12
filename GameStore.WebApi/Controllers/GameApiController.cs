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
    [Route("api/games")]
    [ApiController]
    public class GameApiController : ControllerBase,IGameService
    {
        private readonly IGameService _gameService;

        public GameApiController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Добавление новой игры
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Идентификатор добавленной игры</returns>
        [HttpPost]
        public int Add(GameDTO game)
        {
            return _gameService.Add(game);
        }

        /// <summary>
        /// Удаление игры
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _gameService.Delete(id);
        }

        /// <summary>
        /// Получение списка всех игр
        /// </summary>
        /// <returns>Список игр</returns>
        [HttpGet]
        public IEnumerable<GameDTO> Get()
        {
            return _gameService.Get();
        }

        /// <summary>
        /// Получение игры по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор игры</param>
        /// <returns>Ирга</returns>
        [HttpGet("{id}")]
        public GameDTO Get(int id)
        {
            return _gameService.Get(id);
        }

        /// <summary>
        /// Получение списка игр по жанру
        /// </summary>
        /// <param name="id">Идентификатор жанра</param>
        /// <returns>Список игр</returns>
        [HttpGet("genre/{id}")]
        public IEnumerable<GameDTO> GetByGenre(int id)
        {
            return _gameService.GetByGenre(id);
        }

        /// <summary>
        /// Получение списка игр по жанру
        /// </summary>
        /// <param name="name">Название жанра</param>
        /// <returns>Список игр</returns>
        [HttpGet("genre")]
        public IEnumerable<GameDTO> GetByGenre(string name)
        {
            return _gameService.GetByGenre(name);
        }

        /// <summary>
        /// Получение игры по названию
        /// </summary>
        /// <param name="name">Название игры</param>
        /// <returns>Игра</returns>
        [HttpGet("game")]
        public GameDTO GetByName(string name)
        {
            return _gameService.GetByName(name);
        }

        /// <summary>
        /// Обновление информации игры
        /// </summary>
        /// <param name="game">Игра</param>
        /// <returns>Результат обновления</returns>
        [HttpPut]
        public bool Update(GameDTO game)
        {
            return _gameService.Update(game);
        }
    }
}

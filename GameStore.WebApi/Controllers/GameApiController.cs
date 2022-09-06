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
    [Route("api/game")]
    [ApiController]
    public class GameApiController : ControllerBase,IGameService
    {
        private readonly IGameService _GameService;

        public GameApiController(IGameService GameService)
        {
            _GameService = GameService;
        }

        [HttpPost]
        public int Add(GameDTO Game)
        {
            return _GameService.Add(Game);
        }

        [HttpDelete("Id")]
        public bool Delete(int Id)
        {
            return _GameService.Delete(Id);
        }

        [HttpGet]
        public IEnumerable<GameDTO> Get()
        {
            return _GameService.Get();
        }

        [HttpGet("Id")]
        public GameDTO Get(int Id)
        {
            return _GameService.Get(Id);
        }

        [HttpGet("genre/{Id}")]
        public IEnumerable<GameDTO> GetByGenre(int Id)
        {
            return _GameService.GetByGenre(Id);
        }

        [HttpGet("genre/name/{Name}")]
        public IEnumerable<GameDTO> GetByGenre(string Name)
        {
            return _GameService.GetByGenre(Name);
        }

        [HttpGet("name/{Name}")]
        public GameDTO GetByName(string Name)
        {
            return _GameService.GetByName(Name);
        }

        [HttpPut]
        public bool Update(GameDTO Game)
        {
            return _GameService.Update(Game);
        }
    }
}

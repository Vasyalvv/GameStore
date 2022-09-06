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
    [Route("api/genres")]
    [ApiController]
    public class GenreApiController : ControllerBase,IGenreService
    {
        private readonly IGenreService _GenreService;

        public GenreApiController(IGenreService GenreService)
        {
            _GenreService = GenreService;
        }

        [HttpPost]
        public int Add(GenreDTO Genre)
        {
            return _GenreService.Add(Genre);
        }

        [HttpPost("list")]
        public IEnumerable<GenreDTO> Add(IEnumerable<GenreDTO> Genres)
        {
            return _GenreService.Add(Genres);
        }

        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return _GenreService.Delete(Id);
        }

        [HttpGet]
        public IEnumerable<GenreDTO> Get()
        {
            return _GenreService.Get();
        }

        [HttpGet("{Id}")]
        public GenreDTO Get(int Id)
        {
            return _GenreService.Get(Id);
        }

        [HttpGet("genre")]
        public GenreDTO GetByName(string Name)
        {
            return _GenreService.GetByName(Name);
        }

        [HttpPut]
        public GenreDTO Update(GenreDTO Genre)
        {
            return _GenreService.Update(Genre);
        }
    }
}

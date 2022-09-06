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
    [Route("api/publishers")]
    [ApiController]
    public class PublisherApiController : ControllerBase, IPublisherService
    {
        private readonly IPublisherService _PublisherService;

        public PublisherApiController(IPublisherService PublisherService)
        {
            _PublisherService = PublisherService;
        }


        [HttpPost]
        public int Add(PublisherDTO Publisher)
        {
            return _PublisherService.Add(Publisher);
        }

        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return _PublisherService.Delete(Id);
        }

        [HttpGet]
        public IEnumerable<PublisherDTO> Get()
        {
            return _PublisherService.Get();
        }

        [HttpGet("{Id}")]
        public PublisherDTO Get(int Id)
        {
            return _PublisherService.Get(Id);
        }

        [HttpGet("publisher")]
        public PublisherDTO GetByName(string Name)
        {
            return _PublisherService.GetByName(Name);
        }

        [HttpPut]
        public PublisherDTO Update(PublisherDTO Publisher)
        {
            return _PublisherService.Update(Publisher);
        }
    }
}

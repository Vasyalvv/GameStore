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
    /// API контроллер взаимодействия с сущностью Издатель
    /// </summary>
    [Route("api/publishers")]
    [ApiController]
    public class PublisherApiController : ControllerBase, IPublisherService
    {
        private readonly IPublisherService _publisherService;

        public PublisherApiController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }


        /// <summary>
        /// Добавление нового издателя игр
        /// </summary>
        /// <param name="publisher">Добавляемый издатель</param>
        /// <returns>Идентификатор добавленного издателя, возвращается -1 в случае ошибки</returns>
        [HttpPost]
        public int Add(PublisherDTO publisher)
        {
            return _publisherService.Add(publisher);
        }

        /// <summary>
        /// Удаление издателя игр
        /// </summary>
        /// <param name="id">Идентификатор удаляемого издателя</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _publisherService.Delete(id);
        }

        /// <summary>
        /// Получение списка всех издателей
        /// </summary>
        /// <returns>Список издателей</returns>
        [HttpGet]
        public IEnumerable<PublisherDTO> Get()
        {
            return _publisherService.Get();
        }

        /// <summary>
        /// Получение издателя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор издателя</param>
        /// <returns>Издатель</returns>
        [HttpGet("{id}")]
        public PublisherDTO Get(int id)
        {
            return _publisherService.Get(id);
        }

        /// <summary>
        /// Получение издателя по названию
        /// </summary>
        /// <param name="name">Название издателя</param>
        /// <returns>Издатель</returns>
        [HttpGet("publisher")]
        public PublisherDTO GetByName(string name)
        {
            return _publisherService.GetByName(name);
        }

        /// <summary>
        /// Обновление информации издателя
        /// </summary>
        /// <param name="publisher">Издатель</param>
        /// <returns>Обновленная запись издателя</returns>
        [HttpPut]
        public PublisherDTO Update(PublisherDTO publisher)
        {
            return _publisherService.Update(publisher);
        }
    }
}

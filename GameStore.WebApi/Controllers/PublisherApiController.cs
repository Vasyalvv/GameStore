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
        private readonly IPublisherService _PublisherService;

        public PublisherApiController(IPublisherService PublisherService)
        {
            _PublisherService = PublisherService;
        }


        /// <summary>
        /// Добавление нового издателя игр
        /// </summary>
        /// <param name="Publisher">Добавляемый издатель</param>
        /// <returns>Идентификатор добавленного издателя, возвращается -1 в случае ошибки</returns>
        [HttpPost]
        public int Add(PublisherDTO Publisher)
        {
            return _PublisherService.Add(Publisher);
        }

        /// <summary>
        /// Удаление издателя игр
        /// </summary>
        /// <param name="Id">Идентификатор удаляемого издателя</param>
        /// <returns>Результат удаления</returns>
        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return _PublisherService.Delete(Id);
        }

        /// <summary>
        /// Получение списка всех издателей
        /// </summary>
        /// <returns>Список издателей</returns>
        [HttpGet]
        public IEnumerable<PublisherDTO> Get()
        {
            return _PublisherService.Get();
        }

        /// <summary>
        /// Получение издателя по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор издателя</param>
        /// <returns>Издатель</returns>
        [HttpGet("{Id}")]
        public PublisherDTO Get(int Id)
        {
            return _PublisherService.Get(Id);
        }

        /// <summary>
        /// Получение издателя по названию
        /// </summary>
        /// <param name="Name">Название издателя</param>
        /// <returns>Издатель</returns>
        [HttpGet("publisher")]
        public PublisherDTO GetByName(string Name)
        {
            return _PublisherService.GetByName(Name);
        }

        /// <summary>
        /// Обновление информации издателя
        /// </summary>
        /// <param name="Publisher">Издатель</param>
        /// <returns>Обновленная запись издателя</returns>
        [HttpPut]
        public PublisherDTO Update(PublisherDTO Publisher)
        {
            return _PublisherService.Update(Publisher);
        }
    }
}

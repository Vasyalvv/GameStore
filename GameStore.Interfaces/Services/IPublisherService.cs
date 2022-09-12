using GameStore.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Interfaces.Services
{

    public interface IPublisherService
    {
        /// <summary>
        /// Получить всех издателей
        /// </summary>
        /// <returns>Список издателей</returns>
        IEnumerable<PublisherDTO> Get();

        /// <summary>
        /// Получить издателя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор издателя</param>
        /// <returns>Издатель</returns>
        PublisherDTO Get(int id);

        /// <summary>
        /// Получить издателя по названию
        /// </summary>
        /// <param name="name">Название издателя</param>
        /// <returns>издателя</returns>
        PublisherDTO GetByName(string name);

        /// <summary>
        /// Добавить издателя
        /// </summary>
        /// <param name="publisher">Издатель</param>
        /// <returns>Идентификатор добавленного издателя</returns>
        int Add(PublisherDTO publisher);

        /// <summary>
        /// Обновить данные издателя
        /// </summary>
        /// <param name="publisher">Издатель</param>
        /// <returns>Результат обновления</returns>
        PublisherDTO Update(PublisherDTO publisher);

        /// <summary>
        /// Удалить издателя
        /// </summary>
        /// <param name="id">Идентификатор издателя</param>
        /// <returns>Результат удаления</returns>
        bool Delete(int id);
    }

}

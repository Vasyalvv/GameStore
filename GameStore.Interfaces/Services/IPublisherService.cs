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
        /// <param name="Id">Идентификатор издателя</param>
        /// <returns>Издатель</returns>
        PublisherDTO Get(int Id);

        /// <summary>
        /// Получить издателя по названию
        /// </summary>
        /// <param name="Name">Название издателя</param>
        /// <returns>издателя</returns>
        PublisherDTO GetByName(string Name);


        /// <summary>
        /// Добавить издателя
        /// </summary>
        /// <param name="Publisher">Издатель</param>
        /// <returns>Идентификатор добавленного издателя</returns>
        int Add(PublisherDTO Publisher);

        /// <summary>
        /// Обновить данные издателя
        /// </summary>
        /// <param name="Publisher">Издатель</param>
        /// <returns>Результат обновления</returns>
        PublisherDTO Update(PublisherDTO Publisher);

        /// <summary>
        /// Удалить издателя
        /// </summary>
        /// <param name="Id">Идентификатор издателя</param>
        /// <returns>Результат удаления</returns>
        bool Delete(int Id);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.DTO
{
    /// <summary>
    /// DTO-модель сущности Издатель
    /// </summary>
    public class PublisherDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название издателя
        /// </summary>
        public string Name { get; set; }
    }
}

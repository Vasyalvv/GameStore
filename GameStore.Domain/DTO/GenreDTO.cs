using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.DTO
{
    /// <summary>
    /// DTO-модель сущности Жанр
    /// </summary>
    public class GenreDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название игрового жанра
        /// </summary>
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.DTO
{
    /// <summary>
    /// DTO-модель сущности Игра
    /// </summary>
    public class GameDTO
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название игры
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Издатель игры
        /// </summary>
        public PublisherDTO Publisher { get; set; }

        /// <summary>
        /// Список жанров к которым отностися игра
        /// </summary>
        public IList<GenreDTO> Genres { get; set; } = new List<GenreDTO>();
    }
}

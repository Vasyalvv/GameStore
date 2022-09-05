using GameStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    /// <summary>
    /// Жанр игры
    /// </summary>
    public class Genre:NamedEntity
    {
        public IEnumerable<Game> Games { get; set; } = new List<Game>();
    }
}

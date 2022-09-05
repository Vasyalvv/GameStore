using GameStore.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    /// <summary>
    /// Видеоигра
    /// </summary>
    public class Game : NamedEntity 
    {
        public Publisher Publisher { get; set; }
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}

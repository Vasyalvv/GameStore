using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PublisherDTO Publisher { get; set; }

        public IList<GenreDTO> Genres { get; set; }
    }
}

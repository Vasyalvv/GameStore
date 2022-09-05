using GameStore.Domain.DTO;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Mapping
{
    public static class GenreMapping
    {
        public static GenreDTO ToDTO(this Genre Genre) => new GenreDTO
        {
            Id = Genre.Id,
            Name = Genre.Name
        };

        public static Genre FromDTO(this GenreDTO GenreDTO) => new Genre
        {
            Id = GenreDTO.Id,
            Name = GenreDTO.Name
        };
    }
}

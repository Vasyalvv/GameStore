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
        public static GenreDTO ToDTO(this Genre Genre)
        {
            if (Genre is null)
                return null;

            return new GenreDTO
            {
                Id = Genre.Id,
                Name = Genre.Name
            };
        }

        public static Genre FromDTO(this GenreDTO GenreDTO)
        {
            if (GenreDTO is null)
                return null;

            return new Genre
            {
                Id = GenreDTO.Id,
                Name = GenreDTO.Name
            };
        }
    }
}

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
        public static GenreDTO ToDTO(this Genre genre)
        {
            if (genre is null)
                return null;

            return new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public static Genre FromDTO(this GenreDTO genreDTO)
        {
            if (genreDTO is null)
                return null;

            return new Genre
            {
                Id = genreDTO.Id,
                Name = genreDTO.Name
            };
        }
    }
}

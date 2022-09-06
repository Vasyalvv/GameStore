using GameStore.Domain.DTO;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Mapping
{
    public static class GameMapping
    {
        public static GameDTO ToDTO(this Game Game)
        {
            if (Game is null)
                return null;

            return new GameDTO
            {
                Id = Game.Id,
                Name = Game.Name,
                Publisher = new PublisherDTO
                {
                    Id = Game.Publisher.Id,
                    Name = Game.Publisher.Name
                },
                Genres = new List<GenreDTO>(Game.Genres.Select(g =>
                       new GenreDTO
                       {
                           Id = g.Id,
                           Name = g.Name
                       })
                )
            };
        }

        public static Game FromDTO(this GameDTO GameDTO)
        {
            if (GameDTO is null)
                return null;

            return new Game
            {
                Id = GameDTO.Id,
                Name = GameDTO.Name,
                Publisher = new Publisher
                {
                    Id = GameDTO.Publisher.Id,
                    Name = GameDTO.Publisher.Name
                },
                Genres = new List<Genre>(GameDTO.Genres.Select(g =>
                       new Genre
                       {
                           Id = g.Id,
                           Name = g.Name
                       })
                )
            };
        }
    }
}

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
        public static GameDTO ToDTO(this Game game)
        {
            if (game is null)
                return null;

            return new GameDTO
            {
                Id = game.Id,
                Name = game.Name,
                Publisher = new PublisherDTO
                {
                    Id = game.Publisher.Id,
                    Name = game.Publisher.Name
                },
                Genres = new List<GenreDTO>(game.Genres.Select(g =>
                       new GenreDTO
                       {
                           Id = g.Id,
                           Name = g.Name
                       })
                )
            };
        }

        public static Game FromDTO(this GameDTO gameDTO)
        {
            if (gameDTO is null)
                return null;

            return new Game
            {
                Id = gameDTO.Id,
                Name = gameDTO.Name,
                Publisher = new Publisher
                {
                    Id = gameDTO.Publisher.Id,
                    Name = gameDTO.Publisher.Name
                },
                Genres = new List<Genre>(gameDTO.Genres.Select(g =>
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

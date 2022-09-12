using GameStore.Domain.DTO;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Service.Mapping
{
    public static class PublisherMapping
    {
        public static PublisherDTO ToDTO(this Publisher publisher)
        {
            if (publisher is null)
                return null;

            return new PublisherDTO
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }

        public static Publisher FromDTO(this PublisherDTO publisherDTO)
        {
            if (publisherDTO is null)
                return null;

            return new Publisher
            {
                Id = publisherDTO.Id,
                Name = publisherDTO.Name
            };
        }
    }
}

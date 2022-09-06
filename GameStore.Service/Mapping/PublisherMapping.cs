﻿using GameStore.Domain.DTO;
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
        public static PublisherDTO ToDTO(this Publisher Publisher)
        {
            if (Publisher is null)
                return null;

            return new PublisherDTO
            {
                Id = Publisher.Id,
                Name = Publisher.Name
            };
        }

        public static Publisher FromDTO(this PublisherDTO PublisherDTO)
        {
            if (PublisherDTO is null)
                return null;

            return new Publisher
            {
                Id = PublisherDTO.Id,
                Name = PublisherDTO.Name
            };
        }
    }
}
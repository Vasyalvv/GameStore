using GameStore.Domain.Inerfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities.Base
{
    [Index(nameof(Name), IsUnique = true)]
    public abstract class NamedEntity : Entity, INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Inerfaces
{
    public interface INamedEntity:IEntity
    {
        public string Name { get; set; }
    }
}

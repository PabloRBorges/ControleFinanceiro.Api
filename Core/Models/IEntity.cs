﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Entity
    {
        public Entity() => Id = Guid.NewGuid();

        public Guid Id { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoModel.Common
{
    public abstract class Entity : IEntity
    {
        public virtual int Id { get; set; }
    }
}

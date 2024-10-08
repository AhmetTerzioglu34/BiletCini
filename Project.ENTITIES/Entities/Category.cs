﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        //Relational Properties
        public virtual ICollection<MovieCategory> MovieCategories { get; set; }
    }
}

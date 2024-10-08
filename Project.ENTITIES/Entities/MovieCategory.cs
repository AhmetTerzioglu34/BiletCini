﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class MovieCategory : BaseEntity
    {
        public int MovieID { get; set; }
        public int CategoryID { get; set; }
        //Relatioanal Properties
        public virtual Movie Movie { get; set; }
        public virtual Category Category { get; set; }
    }
}

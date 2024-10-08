﻿using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public Star Star { get; set; }
        public int? AppUserID { get; set; }
        //Relational Properties
        public virtual ICollection<MovieComment> MovieComments { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}

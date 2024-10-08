﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class Session : BaseEntity
    {
        public string ShowTime { get; set; }
        public decimal Price { get; set; }
        //Relational Properties
        public virtual ICollection<SessionScreen> SessionScreens { get; set; }
        public virtual ICollection<SessionMovie> SessionMovies { get; set; }
        public virtual ICollection<SessionTicket> SessionTickets { get; set; }
    }
}

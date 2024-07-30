﻿using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concrates
{
    public class SessionScreenRepository : BaseRepository<SessionScreen> , ISessionScreenRepository
    {
        public SessionScreenRepository( MyContext db) : base(db) 
        {

        }
    }
}

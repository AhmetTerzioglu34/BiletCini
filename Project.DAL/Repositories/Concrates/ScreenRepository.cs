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
    public class ScreenRepository : BaseRepository<Screen> , IScreenRepository
    {
        public ScreenRepository(MyContext db) : base(db) 
        {

        }
    }
}

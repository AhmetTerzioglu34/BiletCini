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
    public class CategoryRepository : BaseRepository<Category> , ICategoryReppository
    {
        public CategoryRepository(MyContext db) : base(db) 
        {

        }
    }
}

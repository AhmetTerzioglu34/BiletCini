﻿using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        readonly ICategoryRepository _iCatRep;
        public CategoryManager(ICategoryRepository iCatRep) : base(iCatRep)
        {
            _iCatRep = iCatRep;
        }
    }
}

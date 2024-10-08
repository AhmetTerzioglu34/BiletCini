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
    public class AppUserRoleManager : BaseManager<AppUserRole>, IAppUserRoleManager
    {
        readonly IAppUserRoleRepository _appUserRoleRep;
        public AppUserRoleManager(IAppUserRoleRepository appUserRoleRep) : base(appUserRoleRep)
        {
            _appUserRoleRep = appUserRoleRep;
        }
    }
}

using Project.BLL.Managers.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Managers.Concretes
{
    public class AppUserProfileManager : BaseManager<AppUserProfile>, IAppUserProfileManager
    {
        readonly IAppUserProfileRepository _profileRep;
        public AppUserProfileManager(IAppUserProfileRepository profileRep) : base(profileRep)
        {
            _profileRep = profileRep;
        }
    }
}

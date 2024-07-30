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
    public class SessionScreenManager : BaseManager<SessionScreen> , ISessionScreenManager
    {
        readonly ISessionScreenRepository _sessionScreenRepository;
        public SessionScreenManager( ISessionScreenRepository sessionScreenRepository) : base(sessionScreenRepository) 
        {
            _sessionScreenRepository = sessionScreenRepository;
        }
    }
}

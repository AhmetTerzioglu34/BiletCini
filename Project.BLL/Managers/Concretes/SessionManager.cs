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
    public class SessionManager : BaseManager<Session> , ISessionManager
    {
        readonly ISessionRepository _sessionRepository;
        public SessionManager(ISessionRepository sessionRepository) : base(sessionRepository) 
        {
            _sessionRepository = sessionRepository;
        }
    }
}

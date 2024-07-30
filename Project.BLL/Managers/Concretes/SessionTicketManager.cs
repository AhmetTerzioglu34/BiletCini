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
    public class SessionTicketManager : BaseManager<SessionTicket> , ISessionTicketManager
    {
        readonly ISessionTicketRepository _sessionTicketRepository;
        public SessionTicketManager(ISessionTicketRepository sessionTicketRepository) : base(sessionTicketRepository)
        {
            _sessionTicketRepository = sessionTicketRepository;
        }
    }
}

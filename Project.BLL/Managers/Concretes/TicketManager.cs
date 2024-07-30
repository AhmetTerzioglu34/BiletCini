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
    public class TicketManager : BaseManager<Ticket> ,ITicketManager
    {
        readonly ITicketRepository _ticketRepository;
        public TicketManager(ITicketRepository ticketRepository) : base(ticketRepository) 
        {
            _ticketRepository = ticketRepository;
        }
    }
}

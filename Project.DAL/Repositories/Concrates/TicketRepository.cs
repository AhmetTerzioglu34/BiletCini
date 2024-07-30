using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concrates
{
    public class TicketRepository : BaseRepository<Ticket> , ITicketRepository
    {
        public TicketRepository(MyContext db) : base(db) 
        {

        }
    }
}

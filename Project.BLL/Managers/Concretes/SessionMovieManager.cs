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
    public class SessionMovieManager : BaseManager<SessionMovie> , ISessionMovieManager
    {
        readonly ISessionMovieRepository _sessionMovieRepository;
        public SessionMovieManager(ISessionMovieRepository sessionMovieRepository) : base(sessionMovieRepository) 
        {
            _sessionMovieRepository = sessionMovieRepository;
        }
    }
}

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
    public class MovieManager : BaseManager<Movie> ,IMovieManager
    {
        readonly IMovieRepository _movieRepository;
        public MovieManager(IMovieRepository movieRepository) : base(movieRepository) 
        {
            _movieRepository = movieRepository;
        }
    }
}

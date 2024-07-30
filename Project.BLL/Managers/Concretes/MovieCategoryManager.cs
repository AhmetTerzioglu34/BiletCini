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
    public class MovieCategoryManager : BaseManager<MovieCategory> , IMovieCategoryManager
    {
        readonly IMovieCategoryRepository _movieCategoryRepository;
        public MovieCategoryManager(IMovieCategoryRepository movieCategoryRepository): base(movieCategoryRepository) 
        {
            _movieCategoryRepository = movieCategoryRepository;
        }
    }
}

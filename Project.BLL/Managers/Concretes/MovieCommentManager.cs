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
    public class MovieCommentManager :BaseManager<MovieComment> , IMovieCommentManager
    {
        readonly IMovieCommentRepository _movieCommentRepository;
        public MovieCommentManager(IMovieCommentRepository movieCommentRepository) : base(movieCommentRepository) 
        {
            _movieCommentRepository = movieCommentRepository;
        }
    }
}

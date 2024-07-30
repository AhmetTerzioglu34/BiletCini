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
    public class MovieCommentRepository : BaseRepository<MovieComment> , IMovieCommentRepository
    {
        public MovieCommentRepository(MyContext db) : base(db) 
        {

        }
    }
}

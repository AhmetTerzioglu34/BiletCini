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
    public class CommentManager : BaseManager<Comment> , ICommentManager
    {
        readonly ICommentRepository _commentRepository;
        public CommentManager(ICommentRepository commentRepository) : base(commentRepository) 
        {
            _commentRepository = commentRepository;
        }
    }
}

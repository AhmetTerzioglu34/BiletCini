using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class MovieComment : BaseEntity
    {
        public int MovieID { get; set; }
        public int CommentID { get; set; }
        //Relational Properties
        public virtual Movie Movie { get; set; }
        public virtual Comment Comment { get; set; }
    }
}

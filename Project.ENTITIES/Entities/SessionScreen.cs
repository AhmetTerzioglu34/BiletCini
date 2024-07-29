using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class SessionScreen : BaseEntity
    {
        public int SessionID { get; set; }
        public int ScreenID { get; set; }
        //Relational Properties
        public virtual Session Session { get; set; }
        public virtual Screen Screen { get; set; }

    }
}

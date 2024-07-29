using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class Screen : BaseEntity
    {
        public ushort Capacity { get; set; }
        public string ScreenName { get; set; }
        public int? PlaceID { get; set; }
        //Relational Properties 
        public virtual Place Place { get; set; }
        public virtual ICollection<SessionScreen> SessionScreens { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Entities
{
    public class Conversation
    {
        public string id { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}

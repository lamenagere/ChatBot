using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Dal.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Conversation> Conversations { get; set; }
        public virtual ICollection<Activity> Messages { get; set; }
    }
}

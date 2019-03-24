using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Dal.Entities
{
    public class Conversation
    {
        public string ConversationId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}

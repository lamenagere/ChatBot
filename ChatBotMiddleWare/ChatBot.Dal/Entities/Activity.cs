using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Dal.Entities
{

    public class Activity
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string ChannelId { get; set; }
        public virtual User User { get; set; }
        public virtual Conversation Conversation { get; set; }
        public string Text { get; set; }
        public string InputHint { get; set; }
        public string ReplyToId { get; set; }
    }

}

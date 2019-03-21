using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Activity
    {

        public string  type { get; set; }
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public string channelId { get; set; }
        public string conversationId { get; set; }
        public string text { get; set; }
        public string replyToId { get; set; }
        public string watermark { get; set; }
        public virtual User user { get; set; }

    }
}

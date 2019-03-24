using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ChatBot.Dal.Entities;

namespace ChatBot.Dal
{
    public class ChatBotContext : DbContext
    {
        public ChatBotContext() : base("DefaultConnection")
        { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
    }
}

using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class ChatBotContext : DbContext
    {

        public ChatBotContext() : base("DefaultConnection")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }

    }
}

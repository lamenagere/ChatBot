using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Dal.Entities;
using ChatBot.Logic;
using System.Data.Entity;

namespace ChatBot.Dal.Repository
{
    public class ConversationRepository : IRepository<Conversation>
    {
        private ChatBotContext context;

        public ConversationRepository(ChatBotContext context)
        {
            this.context = context;
        }


        public void Add(Conversation Entity)
        {
            context.Conversations.Add(Entity);
        }

        public void Delete(Conversation Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Conversation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Conversation GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Conversation Entity)
        {
            throw new NotImplementedException();
        }
    }
}

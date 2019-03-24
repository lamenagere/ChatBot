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
    public class UserRepository : IRepository<User>
    {
        private ChatBotContext context;

        public UserRepository(ChatBotContext context)
        {
            this.context = context;
        }


        public void Add(User Entity)
        {
            context.Users.Add(Entity);
        }

        public void Delete(User Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByID(int Id)
        {
            return context.Users.Single(usr => usr.Id == Id);
        }

        public void Update(User Entity)
        {
            throw new NotImplementedException();
        }
    }
}

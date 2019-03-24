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
    public class ActivityRepository : IRepository<Activity>
    {
        private ChatBotContext context;

        public ActivityRepository(ChatBotContext context)
        {
            this.context = context;
        }


        public void Add(Activity Entity)
        {
            context.Activities.Add(Entity);
        }

        public void Delete(Activity Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Activity GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Activity Entity)
        {
            throw new NotImplementedException();
        }
    }
}

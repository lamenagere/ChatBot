using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBot.Dal.Repository;

namespace ChatBot.Dal
{
    public class ChatBotUnitOfWork : IDisposable
    {
        private readonly ChatBotContext _context = new ChatBotContext();

        public UserRepository UserRepository;
        public ConversationRepository ConversationRepository;
        public ActivityRepository ActivityRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public ChatBotUnitOfWork()
        {
            UserRepository = new UserRepository(_context);
            ConversationRepository = new ConversationRepository(_context);
            ActivityRepository = new ActivityRepository(_context);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}

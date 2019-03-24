using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Logic
{
    public interface IRepository<TEntity>
    {
        TEntity GetByID(int Id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity Entity);

        void Delete(TEntity Entity);

        void Update(TEntity Entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo_DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetOne(int id);
        void Create(TEntity t);
        void Delete(int id);
        void Update(TEntity t);
    }
}

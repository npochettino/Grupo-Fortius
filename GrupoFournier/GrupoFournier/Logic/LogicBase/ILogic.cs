using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface ILogic<T>
    {
        long Add(T entity);

        void Update(T entity);

        void Delete(long ID);

        void LogicDelete(long ID);

        T GetByID(long ID);

        List<T> GetAllActivos();
    }
}

using Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC
{
    public interface IDalc<T>
        where T : class, IEntityBase
    {
        long Add(T entity);

        void Update(T entity);

        void Delete(long ID);

        void LogicDelete(T entity);

        T GetByID(long ID);

        List<T> GetAllActivos();
    }
}

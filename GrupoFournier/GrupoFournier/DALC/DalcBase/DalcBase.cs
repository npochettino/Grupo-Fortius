using DALC.NHibernate;
using Entities;
using Fwk.Session;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC
{
    public abstract class DalcBase<T> : IDalc<T>
    where T : class, IEntityBase, new()
    {

        #region Properties

        public virtual ISession Session
        {
            get
            {
                return NHibernateManager.GetInstance().Session;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Metodo de logica para agregar entidad
        /// </summary>
        /// <param name="entity">entidad a agregar</param>
        /// <returns>id asignado a la entidad</returns>
        public virtual long Add(T entity)
        {
            // -- Agrega entidad
            Session.SaveOrUpdate(entity);
            // -- Flush
            Session.Flush();
            // -- Retorna id
            return entity.EntityID;
        }

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        /// <param name="entity">entidad a actualizar</param>
        public virtual void Update(T entity)
        {
            // -- Actualiza entidad
            Session.Merge(entity);
            // -- Flush
            Session.Flush();
        }

        /// <summary>
        /// BOrra una entidad
        /// </summary>
        /// <param name="entity">id de la entidad</param>
        public virtual void Delete(long ID)
        {
            // -- Obtiene entidad
            var entity = Session.Get<T>(ID);
            // -- Borra entidad
            Session.Delete(entity);
            // -- Flush
            Session.Flush();
        }

        /// <summary>
        /// Baja logicamente una entidad
        /// </summary>
        /// <param name="entity">entidad</param>
        public virtual void LogicDelete(T entity)
        {
            // -- Actualiza entidad
            Session.SaveOrUpdate(entity);
            // -- Flush
            Session.Flush();
        }

        /// <summary>
        /// Recupera entidad por id
        /// </summary>
        /// <param name="ID">id de la entidad</param>
        public virtual T GetByID(long ID)
        {
            // -- Recupera entidad
            return Session.Get<T>(ID);
        }

        /// <summary>
        /// Recupera lista de entidades
        /// </summary>
        /// <returns>lista de entidades</returns>
        public virtual  List<T> GetAllActivos()
        {
            // -- Recupera entidades
            return Session.QueryOver<T>().Where(x => x.Activo).List().ToList();
        }

        #endregion
    }
}

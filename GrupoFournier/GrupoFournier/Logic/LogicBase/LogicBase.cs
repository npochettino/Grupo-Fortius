using DALC;
using DALC.NHibernate;
using Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class LogicBase<T, D> : ILogic<T>
        where T : class, IEntityBase, new()
        where D : DalcBase<T>, new()
    {

        #region Members

        /// <summary>
        /// Dalc
        /// </summary>
        public D Dalc;

        #endregion

        #region Constructor
        /// <summary>
        /// ctor
        /// </summary>
        public LogicBase()
        {
            Dalc = new D();
            //Dalc.Session = NHibernateManager.GetInstance().Session;
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Metodo de logica para agregar entidad
        /// </summary>
        /// <param name="entity">entidad a agregar</param>
        /// <returns>id asignado a la entidad</returns>
        public virtual long Add(T entity)
        {
            return Dalc.Add(entity);
        }

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        /// <param name="entity">entidad a actualizar</param>
        public virtual void Update(T entity)
        {
            Dalc.Update(entity);
        }

        /// <summary>
        /// BOrra una entidad
        /// </summary>
        /// <param name="entity">id entidad a borrar</param>
        public virtual void Delete(long ID)
        {
            Dalc.Delete(ID);
        }

        /// <summary>
        /// Baja logicamente una entidad
        /// </summary>
        /// <param name="entity">id entidad a dar de baja logicamente</param>
        public virtual void LogicDelete(long ID)
        {
            // -- Obtengo la entidad
            T entity = Dalc.GetByID(ID);
            // -- cambio el estado
            entity.Activo = false;
            Dalc.LogicDelete(entity);
        }

        /// <summary>
        /// Recupera entidad por id
        /// </summary>
        /// <param name="ID">id de la entidad</param>
        /// <returns>entidad</returns>
        public virtual T GetByID(long ID)
        {
            return Dalc.GetByID(ID);
        }

        /// <summary>
        /// Recupera lista de entidades
        /// </summary>
        /// <returns>lista de entidades</returns>
        public virtual List<T> GetAllActivos()
        {
            return Dalc.GetAllActivos();
        }
        #endregion
    }
}

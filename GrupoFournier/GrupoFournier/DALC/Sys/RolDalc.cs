using Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALC
{
    public class RolDalc : DalcBase<Rol>
    {
        #region Override Methods

        /// <summary>
        /// Agrega rol
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override long Add(Rol entity)
        {
            return base.Add(entity);
        }

        /// <summary>
        /// Actualiza rol
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(Rol entity)
        {
            base.Update(entity);
        }

        /// <summary>
        /// Borra rol
        /// </summary>
        /// <param name="ID"></param>
        public override void Delete(long ID)
        {
            base.Delete(ID);
        }

        /// <summary>
        /// Borra logicamente rol
        /// </summary>
        /// <param name="entity"></param>
        public override void LogicDelete(Rol entity)
        {
            base.LogicDelete(entity);
        }

        /// <summary>
        /// Recupera rol por id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public override Rol GetByID(long ID)
        {
            return base.GetByID(ID);
        }

        /// <summary>
        /// Recupera roles activos
        /// </summary>
        /// <returns></returns>
        public override List<Rol> GetAllActivos()
        {
            return base.GetAllActivos();
        }

        /// <summary>
        /// Recupera rol en el inicio de la aplicacion
        /// </summary>
        /// <param name="sessionParticular">Session particular para el metodo</param>
        /// <returns></returns>
        public List<Rol> GetAllActivos(ISession sessionParticular)
        {
            return sessionParticular.QueryOver<Rol>().Where(r => r.Activo).List<Rol>().ToList();
        }

        #endregion

        /// <summary>
        /// Recupera roles inferiores al nivel 
        /// </summary>
        /// <param name="nivel">nivel del rol</param>
        /// <returns></returns>
        public List<Rol> GetNivelesInferiores(int nivel)
        {
            return Session.QueryOver<Rol>().Where(x => x.Nivel <= nivel).List().ToList();
        }

        /// <summary>
        /// Recupera rol por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Rol GetByNombre(string nombre)
        {
            return Session.QueryOver<Rol>().Where(x => x.Nombre == nombre).List().ToList().First();
        }
    }
}

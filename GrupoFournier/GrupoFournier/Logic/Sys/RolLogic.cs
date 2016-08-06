using Cross.Common;
using DALC;
using DALC.NHibernate;
using Entities;
using Fwk.Session;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class RolLogic : LogicBase<Rol, RolDalc>
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
            var modulos = base.GetByID(entity.EntityID).Modulos;
            entity.Modulos = modulos;
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
        /// <param name="ID"></param>
        public override void LogicDelete(long ID)
        {
            base.LogicDelete(ID);
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
        /// Recupera rol activos
        /// </summary>
        /// <returns></returns>
        public override List<Rol> GetAllActivos()
        {
            return base.GetAllActivos();
        }

        /// <summary>
        /// Recupera rol activos
        /// </summary>
        /// <returns></returns>
        public List<Rol> GetAllActivos(ISession sessionParticular)
        {
            return base.Dalc.GetAllActivos(sessionParticular);
        }

        /// <summary>
        /// Actualiza modulos de
        /// </summary>
        public void UpdateModulos(Rol rol)
        {
            Rol rolActual = base.Dalc.GetByID(rol.EntityID);
            rolActual.Modulos = rol.Modulos;
            base.Dalc.Update(rolActual);
        }

        #endregion

        /// <summary>
        /// Recupera roles inferiores a empresa
        /// </summary>
        /// <returns></returns>
        public List<Rol> GetInferioresEmpresa()
        {
            // -- Recupero rol empresa
            //var rolEmpresa = Dalc.GetByNombre("Empresa");
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);            
            // -- Recupero roles inferiores a empresa
            //return Dalc.GetNivelesInferiores(rolEmpresa.Nivel);
            return Dalc.GetNivelesInferiores(usuarioLogueado.Rol.Nivel);
        }

        public List<Rol> GetRolesParaCursos()
        {
            // -- Recupero rol Alto
            var rolAlto = Dalc.GetByNombre("Alto");
            // -- Recupero roles inferiores a rol
            return Dalc.GetNivelesInferiores(rolAlto.Nivel);
        }
    }
}

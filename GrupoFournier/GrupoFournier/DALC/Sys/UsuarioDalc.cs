using Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cross.Common;

namespace DALC
{
    public class UsuarioDalc: DalcBase<Usuario>
    {
        #region Override

        /// <summary>
        /// Agrega usuario
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override long Add(Usuario entity)
        {
            return base.Add(entity);
        }

        /// <summary>
        /// Actualiza Usuario
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(Usuario entity)
        {
            base.Update(entity);
        }

        /// <summary>
        /// Borra Usuario
        /// </summary>
        /// <param name="ID"></param>
        public override void Delete(long ID)
        {
            base.Delete(ID);
        }

        /// <summary>
        /// Borra logicamente usuario
        /// </summary>
        /// <param name="entity"></param>
        public override void LogicDelete(Usuario entity)
        {
            base.LogicDelete(entity);
        }

        /// <summary>
        /// Recupera usuario por id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public override Usuario GetByID(long ID)
        {
            return base.GetByID(ID);
        }

        /// <summary>
        /// Recupera usuario activos
        /// </summary>
        /// <returns></returns>
        public override List<Usuario> GetAllActivos()
        {
            return base.GetAllActivos();
        }
        #endregion

        #region Custom Methods

        /// <summary>
        /// Recupera usuario por nombre usuario
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public Usuario GetByNombreUsuario(string nombreUsuario)
        {
            return Session.QueryOver<Usuario>().Where(x => x.NombreUsuario == nombreUsuario.ToLower()).List().FirstOrDefault();
        }

        /// <summary>
        /// Recupera usuarios de una empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<Usuario> GetByEmpresa(long idEmpresa)
        {
            return Session.QueryOver<Usuario>().Where(x => x.Empresa.EntityID == idEmpresa).List().ToList();
        }

        /// <summary>
        /// Recupera usuarios con nivel inferior al usuario logueado
        /// </summary>
        /// <param name="nivel"></param>
        /// <returns></returns>
        public List<Usuario> GetUsuarioRolInferior(int nivel)
        {
            return Session.QueryOver<Usuario>().Where(x => x.Activo).JoinQueryOver<Rol>(x => x.Rol).Where(x => x.Nivel <= nivel).List().ToList();
        }

        /// <summary>
        /// Recupera los usuarios empresa a los que les debo enviar el mail que un usuario de su empresa finalizo un curso
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetUsuarioEmpresaParaMail(long empresaID)
        {
            List<Usuario> usus = Session.QueryOver<Usuario>().Where(x => x.Activo && x.IsMailCursoTerminado).JoinQueryOver<Rol>(x => x.Rol).Where(x => x.EntityID <= Convert.ToInt64(Global.Roles.EMPRESA)).List().ToList();
            return usus;
        }

        #endregion
    }
}

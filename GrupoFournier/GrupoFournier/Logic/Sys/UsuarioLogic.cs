using Cross.Common;
using DALC;
using DALC.NHibernate;
using Entities;
using Fwk.Crypto;
using Fwk.Session;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class UsuarioLogic : LogicBase<Usuario, UsuarioDalc>
    {
        #region Overrides

        /// <summary>
        /// Agregar usuario
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override long Add(Usuario entity)
        {
            Usuario usuarioExistente = Dalc.GetByNombreUsuario(entity.NombreUsuario);
            if (usuarioExistente != null)
            {
                return -99;
            }            
            return base.Add(entity);
        }

        /// <summary>
        /// Actualizar Usuario
        /// </summary>
        /// <param name="entity"></param>
        public override void Update(Usuario entity)
        {
            base.Update(entity);
        }

        /// <summary>
        /// Borra usuario
        /// </summary>
        /// <param name="ID"></param>
        public override void Delete(long ID)
        {
            base.Delete(ID);
        }

        /// <summary>
        /// Borra logicamente usuario
        /// </summary>
        /// <param name="ID"></param>
        public override void LogicDelete(long ID)
        {
            base.LogicDelete(ID);
        }

        /// <summary>
        /// Recupera usuario por id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public override Usuario GetByID(long ID)
        {
            Usuario usuario = base.GetByID(ID);
            //usuario.Password = Cryptography.Decrypt(usuario.Password);
            return usuario;
        }

        /// <summary>
        /// Recupera usuarios activo
        /// </summary>
        /// <returns></returns>
        public override List<Usuario> GetAllActivos()
        {
            return base.GetAllActivos();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string nombreUsuario, string password)
        {
            // -- Recupera usuario por nombre de usuario
            Usuario usuario = Dalc.GetByNombreUsuario(nombreUsuario);
            // -- Si no lo encuentro
            if (usuario == null)
            {
                // -- Devuelvo false ya que no existe
                return false;
            }
            // -- Si no esta habilitado
            if (!usuario.Habilitado)
            {
                // -- Devuelvo false ya q no puede ingresar
                return false;
            }
            // -- Password desencriptada
            string originalPassword = Cryptography.Decrypt(usuario.Password);
            // -- Si las contrasenas no coinciden
            if (!originalPassword.Equals(password))
            {
                // -- Devuelvo false porque no son iguales
                return false;
            }
            usuario.Rol.Modulos = null;
            SessionManager.Set(Global.SessionsKeys.USER_SESSION, usuario);
            return true;
        }

        /// <summary>
        /// Cambia contrasena de un usuario
        /// </summary>
        /// <param name="usuarioID"></param>
        /// <param name="newPassword"></param>
        /// <param name="password"></param>
        /// <returns>resultado si cambio contrasena</returns>
        public bool ChangePassword(long usuarioID, string newPassword, string currentPassword)
        {
            Usuario user = base.GetByID(usuarioID);
            if (Cryptography.Decrypt(user.Password).Equals(currentPassword))
            {
                user.Password = Cryptography.Encrypt(newPassword);
                base.Update(user);
                return true;
            }
            return false;
        }

        #endregion

        /// <summary>
        /// Recupera usuarios por empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public List<Usuario> GetByEmpresa(long idEmpresa)
        {
            return base.Dalc.GetByEmpresa(idEmpresa);
        }

        /// <summary>
        /// Recupera usuarios con nivel inferior al usuario logueado
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetUsuarioRolInferior()
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            return Dalc.GetUsuarioRolInferior(usuarioLogueado.Rol.Nivel);
        }

        /// <summary>
        /// Recupera los usuarios empresa a los que les debo enviar el mail que un usuario de su empresa finalizo un curso
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetUsuarioEmpresaParaMail(long empresaID)
        {
            return Dalc.GetUsuarioEmpresaParaMail(empresaID);
        }
    }
}

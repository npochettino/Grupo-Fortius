using Cross.Common;
using Entities;
using Fwk.Crypto;
using Fwk.Session;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.GrupoFournier;

namespace PresentacionGrupoFournier.Controllers.Sys
{
    public class UsuarioController : BaseController<Usuario, UsuarioLogic>
    {

        #region Actions
        // GET: Usuario
        /// <summary>
        /// Vista de grilla para usuarios
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //var usuario = logic.GetAllActivos();
            var usuario = logic.GetUsuarioRolInferior();
            return View(usuario);
        }

        /// <summary>
        /// Vista de creacion/edicion de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Save(long? id)
        {
            Usuario usuario;
            //Si id es null estoy creando un nuevo usuario
            if (id == null)
            {
                usuario = new Usuario();
                usuario.Habilitado = true;
                usuario.Password = GeneratePassword();
                ViewBag.Title = "Crear Usuario";
                ViewBag.isEditando = false;
            }
            else
            {
                ViewBag.Title = "Editar Usuario";
                usuario = logic.GetByID(id.Value);
                usuario.Password = Cryptography.Decrypt(usuario.Password);
                ViewBag.selectedddlRol = usuario.Rol.EntityID;
                ViewBag.selectedddlEmpresa = usuario.Empresa.EntityID;
                ViewBag.isEditando = true;

            }
            return View(usuario);
        }

        /// <summary>
        /// Guarda un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="ClienteID"></param>
        /// <param name="ClienteNombre"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save([Bind]Usuario usuario, long ddlRol, long? ddlEmpresa, bool? isMailCursoTerminado)
        {
            //Agrego el rol
            usuario.Rol = new Rol { EntityID = ddlRol };
            // -- Agrego Empresa
            usuario.Empresa = new Empresa { EntityID = ddlEmpresa.HasValue ? ddlEmpresa.Value : SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION).Empresa.EntityID };
            //indica si se le va a mandar un mail al usuario cada vez que un usuario de esa empresa finalice un curso
            usuario.IsMailCursoTerminado = isMailCursoTerminado.HasValue ? isMailCursoTerminado.Value : false;
            if (ModelState.IsValid)
            {
                // -- Encripto contrasena
                usuario.Password = Cryptography.Encrypt(usuario.Password);
                // Seteo activo
                usuario.Activo = true;
                //Si es un nuevo usuario
                if (usuario.EntityID == 0)
                {
                    //Seteo el nombre de uusario en minusculas
                    usuario.NombreUsuario = usuario.NombreUsuario.ToLower();
                    //Seteo si esta editando
                    ViewBag.isEditando = false;
                    //Seteo titulo
                    ViewBag.Title = "Crear Usuario";

                    if (usuario.NombreUsuario.Contains(" "))
                    {
                        //Seteo error
                        ModelState.AddModelError("NombreUsuario", "El nombre de usuario no puede contener espacios en blanco");
                    }
                    else if (logic.Add(usuario) == -99)//Si hay error al agregar
                    {
                        //Seteo selected rol
                        ViewBag.selectedddlRol = ddlRol;
                        //Seteo selected empresa
                        ViewBag.selectedddlEmpresa = ddlEmpresa;
                        //Seteo error
                        ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya se encuentra en uso");
                    }
                    else
                    {
                        MailLogic mlog = new MailLogic();
                        mlog.EnviarEmail(usuario.EntityID, string.Empty, Global.MailsTypes.REGISTRO);
                        //Redirecciono al index si no hubo error
                        TempData["SaveSuccess"] = "Se guardó usuario correctamente";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    //Actualizo usuario
                    logic.Update(usuario);
                    //Redirecciono al index si no hubo error
                    TempData["SaveSuccess"] = "Se guardó usuario correctamente";
                    return RedirectToAction("Index");
                }
            }
            if (usuario.EntityID == 0)
            {
                ViewBag.isEditando = false;
            }
            else
            {
                ViewBag.isEditando = true;
            }
            return View(usuario);


        }

        /// <summary>
        /// Vista para cambiar contrasena
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ChangePassword(long? id, bool isEmpresa)
        {
            ViewBag.isEmpresa = isEmpresa;
            //Cambia el pass para el usuario que se encuentra logueado
            if (id == null)
            {
                // -- Obtengo usuario de sesion
                Usuario user = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
                // -- Seteo que edito el actual
                ViewBag.isCurrentUser = true;
                // -- Retorno vista
                return View(user);
            }
            else
            {
                // -- Obtengo usuario por id
                Usuario user = logic.GetByID(id.Value);
                // -- Desencripto password
                user.Password = Cryptography.Decrypt(user.Password);
                // -- Genero nueva contrasena
                string newPassword = GeneratePassword();
                // -- Asigno nueva contrasena
                user.NewPassword = newPassword;
                // -- Asigno nueva contrasena
                user.NewPasswordRepeat = newPassword;
                // -- Seteo que no se edita el usuario actual
                ViewBag.isCurrentUser = false;
                // -- Retorno vista
                return View(user);
            }
        }

        /// <summary>
        /// Cambia la contraseña de un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword([Bind]Usuario usuario, bool isCurrentUser)
        {
            if (!usuario.NewPassword.Equals(usuario.NewPasswordRepeat))
            {
                ModelState.AddModelError("NewPassword", "Las contraseñas deben coincidir");
                ViewBag.isCurrentUser = isCurrentUser;
                return View(usuario);
            }
            if (logic.ChangePassword(usuario.EntityID, usuario.NewPassword, usuario.Password))
            {
                MailLogic mlog = new MailLogic();
                mlog.EnviarEmail(usuario.EntityID, usuario.NewPassword, Global.MailsTypes.CAMBIO_CONTRASEÑA);
                TempData["SaveSuccess"] = "Se cambió la contraseña correctamente";
                if (isCurrentUser)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.isCurrentUser = isCurrentUser;
            ModelState.AddModelError("Password", "La contraseña actual ingresada no es correcta");

            return View(usuario);
        }

        /// <summary>
        /// Vista de usuarios para empresa logueada
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexEmpresa()
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupero usuarios por empresa
            var usuarios = logic.GetByEmpresa(usuarioLogueado.Empresa.EntityID);
            // -- Devuelvo vilsta
            return View(usuarios);
        }


        /// <summary>
        /// Vista de creacion/edicion de usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SaveUsuarioEmpresa(long? id)
        {
            Usuario usuario;
            //Si id es null estoy creando un nuevo usuario
            if (id == null)
            {
                usuario = new Usuario();
                usuario.Habilitado = true;
                usuario.Password = GeneratePassword();
                ViewBag.Title = "Crear Usuario";
                ViewBag.isEditando = false;
            }
            else
            {
                ViewBag.Title = "Editar Usuario";
                usuario = logic.GetByID(id.Value);
                usuario.Password = Cryptography.Decrypt(usuario.Password);
                ViewBag.selectedddlRol = usuario.Rol.EntityID;
                ViewBag.isEditando = true;

            }
            return View(usuario);
        }

        /// <summary>
        /// Guarda un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="ClienteID"></param>
        /// <param name="ClienteNombre"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SaveUsuarioEmpresa([Bind]Usuario usuario, long ddlRol, bool? isMailCursoTerminado)
        {
            //Agrego el rol
            usuario.Rol = new Rol { EntityID = ddlRol };
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Agrego Empresa
            usuario.Empresa = new Empresa { EntityID = usuarioLogueado.Empresa.EntityID };
            //indica si se le va a mandar un mail al usuario cada vez que un usuario de esa empresa finalice un curso
            usuario.IsMailCursoTerminado = isMailCursoTerminado.HasValue ? isMailCursoTerminado.Value : false;
            if (ModelState.IsValid)
            {
                // -- Encripto contrasena
                usuario.Password = Cryptography.Encrypt(usuario.Password);
                // Seteo activo
                usuario.Activo = true;
                //Si es un nuevo usuario
                if (usuario.EntityID == 0)
                {
                    //Seteo el nombre de uusario en minusculas
                    usuario.NombreUsuario = usuario.NombreUsuario.ToLower();
                    //Seteo si esta editando
                    ViewBag.isEditando = false;
                    //Seteo titulo
                    ViewBag.Title = "Crear Usuario";

                    //Si hay error al agregar
                    if (logic.Add(usuario) == -99)
                    {
                        //Seteo selected rol
                        ViewBag.selectedddlRol = ddlRol;
                        //Seteo error
                        ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya se encuentra en uso");
                    }
                    else
                    {
                        //Redirecciono al index si no hubo error
                        MailLogic mlog = new MailLogic();
                        mlog.EnviarEmail(usuario.EntityID, string.Empty, Global.MailsTypes.REGISTRO);
                        TempData["SaveSuccess"] = "Se guardó usuario correctamente";
                        return RedirectToAction("IndexEmpresa");
                    }
                }
                else
                {
                    //Actualizo usuario
                    logic.Update(usuario);
                    //Redirecciono al index si no hubo error
                    TempData["SaveSuccess"] = "Se guardó usuario correctamente";
                    return RedirectToAction("IndexEmpresa");
                }
            }
            if (usuario.EntityID == 0)
            {
                ViewBag.isEditando = false;
            }
            else
            {
                ViewBag.isEditando = true;
            }
            return View(usuario);


        }

        #endregion

        #region Custom methods

        /// <summary>
        /// Genera Password valido
        /// </summary>
        /// <returns></returns>
        private string GeneratePassword()
        {
            string minusChars = "abcdefghijklmnopqrtuvwxyz";
            string mayusChars = minusChars.ToUpper();
            string numbers = "0123456789";

            char[] chars = new char[6];
            Random rd = new Random();

            chars[0] = mayusChars[rd.Next(0, mayusChars.Length)];
            chars[1] = minusChars[rd.Next(0, minusChars.Length)];
            chars[2] = numbers[rd.Next(0, numbers.Length)];
            chars[3] = mayusChars[rd.Next(0, mayusChars.Length)];
            chars[4] = minusChars[rd.Next(0, minusChars.Length)];
            chars[5] = numbers[rd.Next(0, numbers.Length)];

            return new string(chars);
        }

        #endregion
    }
}
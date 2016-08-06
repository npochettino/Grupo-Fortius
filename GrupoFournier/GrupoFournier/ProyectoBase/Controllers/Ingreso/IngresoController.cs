using Cross.Common;
using Fwk.Session;
using Logic;
using PresentacionGrupoFournier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PresentacionGrupoFournier.Controllers.Ingreso
{
    public class IngresoController : Controller
    {
        #region Logic

        /// <summary>
        /// Usuario Logic
        /// </summary>
        UsuarioLogic UsuarioLogic
        {
            get
            {
                return new UsuarioLogic();
            }
        }

        #endregion

        // GET: Ingreso
        /// <summary>
        /// Muestra vista de login
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {            
            return View();
        }

        /// <summary>
        /// Loguea
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool valido = UsuarioLogic.Login(model.NombreUsuario, model.Password);
                if (valido)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Seteo error
                    ModelState.AddModelError("NombreUsuario", "Usuario o contraseña incorrectos");
                }
            }
            return View(model);
        }

        /// <summary>
        /// GET -> LogOut usuario
        /// </summary>        
        /// <returns>ActionResult</returns>
        public ActionResult Logout()
        {
            // -- Deslogueo borrando de session
            SessionManager.Set(Global.SessionsKeys.USER_SESSION, null);
            // -- Redirijo a logueo
            return RedirectToAction("Login", "Ingreso");
        }
    }
}
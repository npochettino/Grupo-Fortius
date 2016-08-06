using Cross.Common;
using Entities;
using Fwk.Session;
using Logic;
using PresentacionGrupoFournier.Fwk.UI;
using PresentacionGrupoFournier.Globales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PresentacionGrupoFournier.Controllers
{
    public class HomeController : Controller
    {

        #region Override

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Obtengo id del perfil actual
            if (SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION) == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary { { "controller", "Ingreso" }, { "action", "Login" } });
            }
            base.OnActionExecuting(filterContext);
        }

        #endregion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Menu recursivo lateral
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult RenderMenuRecursivo()
        {
            // -- Recupero usuario de sesion
            var usuario = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Recupero el rol del usuario de variables de aplicacion
            var rol = VariablesAplicacion.Roles.Where(r => r.EntityID == usuario.Rol.EntityID).First();
            // -- Obtengo menu del rol
            string model = rol.MenuHTML;

            return PartialView("_RenderMenuRecursivo", model);
        }

        /// <summary>
        /// GET -> Setea los datos del Usuario
        /// </summary>
        /// <returns>ActionResult</returns>
        [ChildActionOnly]
        public ActionResult RenderDatosUsuario()
        {
            //return RedirectToAction("SaveUsuarioEmpresa", "Usuario", SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION).EntityID);
            return PartialView("_RenderDatosUsuario", SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION));
        }

        [ChildActionOnly]
        public ActionResult RenderLogoEmpresa()
        {
            // -- Obtengo usuario
            var usuario = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            // -- Obtengo empresa
            EmpresaLogic empresaLogic = new EmpresaLogic();
            var empresa = empresaLogic.GetByID(usuario.Empresa.EntityID);

            string appPath = HttpContext.Server.MapPath("~/Imagenes/LogosEmpresas/" + empresa.Imagen);
            // -- Valido que exista imagen de la empresa
            if (System.IO.File.Exists(appPath))
            {
                // -- Si existe la devuelvo
                return PartialView("_RenderLogoEmpresa", "/Imagenes/LogosEmpresas/" + empresa.Imagen);
            }
            else
            {
                // -- Si no existe muestro la de fortius
                return PartialView("_RenderLogoEmpresa", "/Imagenes/header-logo-fortius.png");
            }
        }
    }
}
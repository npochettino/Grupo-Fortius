using Cross.Common;
using DALC.NHibernate;
using Entities;
using Fwk.Exceptions;
using Fwk.Session;
using Logic;
using PresentacionGrupoFournier.Globales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PresentacionGrupoFournier.Controllers
{
    public class BaseController<T, L> : Controller
        where T : IEntityBase
        where L : class, ILogic<T>, new()
    {
        #region Members

        /// <summary>
        /// Generic A -> Adapter member
        /// </summary>
        public L logic;

        #endregion

        #region Constructor

        /// <summary>
        /// Ctor
        /// </summary>
        public BaseController()
        {
            // -- Devuelvo la intancia de la logic
            logic = new L();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Ejecuta las llamadas a los controllers de MVC , que invocan este metodo,
        /// y atrapa las excepciones que se generan en las capas inferiores
        /// </summary>
        /// <typeparam name="T">Mayormente ActionResult, pero puede ser cualquier otro tipo tambien.</typeparam>
        /// <param name="code">Codigo que se delega a este metodo para su ejecucion.</param>
        /// <returns></returns>
        public E ExecuteResponse<E>(Func<E> code)
            where E : class, new()
        {

            E e = new E();

            try
            {
                // -- Ejecuta el codigo y devuelve el resultado del action result
                e = code.Invoke();
            }
            catch (ExceptionHandler)
            {
                return null;
            }

            return e;
        }

        /// <summary>
        /// Redirecciona a la la acción -> "Error/NotFound"
        /// </summary>
        public ActionResult NotFound()
        {
            return RedirectToAction("NotFound", "Error");
        }

        /// <summary>
        /// Redirecciona a la la acción -> "Error/NoAutorizado"
        /// </summary>
        public ActionResult NoAutorizado()
        {
            return RedirectToAction("NoAutorizado", "Error");
        }

        /// <summary>
        /// Retorna -> HttpStatusCode.BadRequest
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult BadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        #endregion

        #region Overrided Methods

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // -- Obtengo usuario logueado
            var usuarioLogueado = SessionManager.Get<Usuario>(Global.SessionsKeys.USER_SESSION);
            //  -- Si no esta logueado
            if (usuarioLogueado == null)
            {
                // -- Redirige a logueo
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary { { "controller", "Ingreso" }, { "action", "Login" } });
            }
            else
            {
                // -- Si no es una child action o un ajax
                if (!filterContext.IsChildAction && !filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    // -- Obtengo rol del usuario
                    Rol rol = VariablesAplicacion.Roles.Where(r => r.EntityID == usuarioLogueado.Rol.EntityID).First();
                    // -- Obtengo controlador llamado
                    string controlador = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                    // -- Obtengo accion
                    string accion = filterContext.ActionDescriptor.ActionName;
                    // -- Formo modulo de seguridad al que desea acceder
                    string actionName = string.Empty;
                    // -- Si es Index
                    if (accion.ToLower().Equals("index"))
                    {
                        // -- Armo modulo
                        actionName = String.Format("/{0}", controlador);
                    }
                    else
                    {
                        // -- Armo modulo
                        actionName = String.Format("/{0}/{1}", controlador, accion);
                    }
                    if (!rol.Modulos.Any(m => m.Action == actionName && m.Activo && m.Enabled))
                    {
                        // -- Armo modulo
                        actionName = String.Format("/{0}/{1}", controlador, accion);
                        // -- Este if sirve para los casos donde hay un index que recibe un parametro
                        if (!rol.Modulos.Any(m => m.Action == actionName && m.Activo && m.Enabled))
                        {
                            // -- Redirige a logueo
                            filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary { { "controller", "Error" }, { "action", "NoAutorizado" } });
                        }
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Metodo que se ejecuta luego de ejecutar una Action.
        /// </summary>
        /// <param name="filterContext">ActionExecutedContext</param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //// -- Handler de Alertas/Errores a Presentación
            //ViewData.Add(TempDataKey.ALERT_KEY, adapter.MyAlerts);
            //// -- Desconectamos luego de ejecutar el action
            //Connection.GetInstance().Disconnect();
            //NHibernateManager.GetInstance().CleanSession();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // -- Cierro la sesion abierta
            NHibernateManager.GetInstance().CloseSession();
            base.OnResultExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            // -- Pregunto si la excepción viene manejada
            // -- Pregunto si es un request de Ajax
            if (filterContext.ExceptionHandled || filterContext.HttpContext.Request.IsAjaxRequest())
            {
                // -- Salgo
                return;
            }
            else
            {
                Exception e = filterContext.Exception;
                // -- Ver que hacer con la exception
                filterContext.ExceptionHandled = true;
                // -- Redirigimos a la página de error
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Index", filterContext = filterContext }));
            }
        }

        #endregion
    }
}
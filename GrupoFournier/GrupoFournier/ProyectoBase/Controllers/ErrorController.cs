using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionGrupoFournier.Controllers
{
    public class ErrorController : Controller
    {
        #region Actions

        /// <summary>
        /// GET -> Index Errores
        /// </summary>
        /// <returns>ViewResult/returns>
        public ViewResult Index()
        {
            return View("Error");
        }

        /// <summary>
        /// GET -> No se encontró el recurso
        /// </summary>
        /// <returns>ActionResult</returns>
        public ViewResult NotFound()
        {
            // -- No se encontró el recurso
            Response.StatusCode = 404;
            return View();
        }

        /// <summary>
        /// GET -> No tiene acceso
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult NoAutorizado()
        {
            return View();
        }

        #endregion
    }
}
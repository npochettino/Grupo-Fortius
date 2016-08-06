using Entities;
using Logic;
using PresentacionGrupoFournier.Fwk.UI;
using PresentacionGrupoFournier.Globales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionGrupoFournier.Controllers.Sys
{
    public class PanelDeControlController : BaseController<Rol, RolLogic>
    {
        // GET: PanelDeControl
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Reinicia variables de aplicacion
        /// </summary>
        /// <returns></returns>
        public ActionResult ReiniciarVariablesAplicacion()
        {
            // -- Actualizo los roles
            VariablesAplicacion.Roles = logic.GetAllActivos();
            // -- Creo los menu
            Menu.CreateRolesMenu();
            // -- Redirijo al Index
            return RedirectToAction("Index");
        }
    }
}
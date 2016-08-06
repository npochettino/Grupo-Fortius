using Entities;
using Logic;
using MvcCustomHelpers.Classes;
using PresentacionGrupoFournier.Fwk.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionGrupoFournier.Controllers.Sys
{
    public class RolController : BaseController<Rol, RolLogic>
    {
        // GET: Rol
        /// <summary>
        /// Vista de lista de roles
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            // -- Obtengo listado
            var model = logic.GetAllActivos();
            // -- Retorno vista
            return View(model);
        }

        /// <summary>
        /// Vista de guardar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Save(long? id)
        {
            // -- Defino rol
            Rol rol;
            // -- Si el id es nulo estacreando
            if (id == null)
            {
                // -- Seteo titulo
                ViewBag.Title = "Crear Rol";
                // -- Instancio rol
                rol = new Rol();
            }
            else
            {
                // -- Seteo titulo
                ViewBag.Title = "Editar Rol";
                // -- Obtengo rol
                rol = logic.GetByID(id.Value);
                // -- Si no existe rol
                if (rol == null)
                {
                    // -- Redirijo a error
                    base.BadRequest();
                }
            }
            return View(rol);
        }

        /// <summary>
        /// Agrega o actualiza un rol
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Rol model)
        {
            // -- Si el modelo es valido
            if(ModelState.IsValid)
            {
                // -- Si se esta creando
                if(model.EntityID==0)
                {
                    // -- Lo seteo como activo
                    model.Activo = true;
                    // -- Lo creo
                    logic.Add(model);
                }
                else
                {
                    // -- Lo actualizo
                    logic.Update(model);
                }
                TempData["SaveSuccess"] = "Se guardó rol correctamente";
                // -- Redirijo a index
                return RedirectToAction("Index", "Rol");
            }
            // -- Retorno vista 
            return View(model);
        }


        /// <summary>
        /// GET -> Perfiles / Modulos
        /// </summary>
        /// <param name="id">ID Perfil</param>
        /// <returns>ActionResult</returns>
        public ActionResult RolModules(long? id)
        {
            // -- Si id es nulo se redirige
            if (id == null)
            {
                return this.BadRequest();
            }
            // -- Recupero el rol con sus módulos
            Rol rol = logic.GetByID(id.Value);
            // -- Si no encuentra el perfil se redirige
            if (rol.EntityID == 0)
            {
                return this.NotFound();
            }

            ViewBag.tree = Arbol.MakeTree(rol.Modulos.ToList());

            return View(rol);
        }

        /// <summary>
        /// POST -> Perfiles / Modulos
        /// </summary>
        /// <param name="profile">Profile</param>
        /// <param name="ModulesID">ID Modulo</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public ActionResult RolModules([Bind] Rol rol, string ModulesID)
        {
            try
            {
                // -- Inicializo la lista de módulo como vacía
                rol.Modulos = new List<Module>();

                // -- Transformo cada id recibido como string en long y creo un modulo para cada uno
                if (ModulesID.Contains(","))
                {
                    ModulesID.Split(',').ToList().ForEach(x => rol.Modulos.Add(new Module { EntityID = Convert.ToInt64(x) }));
                }
                else
                {
                    rol.Modulos = new List<Module>();
                }
                logic.UpdateModulos(rol);
                TempData["SaveSuccess"] = "Se guardaron modulos correctamente";
                return RedirectToAction("Index", "Rol");

            }
            catch (Exception)
            {
                ViewBag.tree = Arbol.MakeTree(rol.Modulos.ToList());

                return View(rol);
            }
        }
    }
}
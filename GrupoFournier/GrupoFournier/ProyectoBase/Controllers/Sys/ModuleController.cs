using Entities;
using Logic;
using MvcCustomHelpers.Classes;
using PresentacionGrupoFournier.Fwk.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace PresentacionGrupoFournier.Controllers.Sys
{
    public class ModuleController : BaseController<Module, ModuleLogic>
    {
        #region Enum

        enum TipoModulo
        {
            [EnumMember(Value = "Acción e Item de  Menú")]
            Modulo = 1,
            [EnumMember(Value = "Item de Menú sin Acción")]
            ItemDeMenú = 2,
            [EnumMember(Value = "Acción fuera del Menú")]
            Acción = 3,
        }

        #endregion        

        #region Acciones

        /// <summary>
        /// GET -> Index Módulo
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Index()
        {
            var modules = logic.GetAllActivos();
            return View(modules);
        }

        /// <summary>
        /// GET -> Crear Módulo
        /// </summary>
        /// <returns>ActionResult</returns>
        public ActionResult Create()
        {
            CargarTipoModulos(1);
            ViewBag.tree = Arbol.MakeTree(0);
            return View();
        }

        /// <summary>
        /// POST -> Crear Módulo
        /// </summary>
        /// <param name="module">Module</param>
        /// <param name="ParentID">ID Padre</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Module module, long ParentID, int TipoModulo)
        {
            module.Type = TipoModulo;
            if (ModelState.IsValid)
            {
                // -- Creo el parent solo si eligió alguno
                if (ParentID != 0)
                {
                    module.Parent = new Module { EntityID = ParentID };
                }
                module.Activo = true;
                logic.Add(module);
                TempData["SaveSuccess"] = "Se guardó módulo correctamente";
                return RedirectToAction("Index", "Module");
            }
            CargarTipoModulos(module.Type);
            ViewBag.tree = Arbol.MakeTree(ParentID);
            return View(module);
        }

        /// <summary>
        /// GET -> Editar Módulo
        /// </summary>
        /// <param name="id">ID Módulo</param>
        /// <returns>ActionResult</returns>
        public ActionResult Edit(long? id)
        {
            // -- Si id es nulo se redirige
            if (id == null)
            {
                return this.BadRequest();
            }

            Module module = logic.GetByID(id.Value);

            // -- Si no encuentra el modulo se redirige
            if (module.EntityID == 0)
            {
                return this.NotFound();
            }

            long parentID = 0;

            if (module.Parent != null)
            {
                parentID = module.Parent.EntityID;
            }
            CargarTipoModulos(module.Type);
            ViewBag.tree = Arbol.MakeTree(parentID);
            return View(module);
        }

        /// <summary>
        /// POST -> Editar Módulo
        /// </summary>
        /// <param name="module">Module</param>
        /// <param name="ParentID">ID Padre</param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind] Module module, long ParentID, int TipoModulo)
        {
            module.Type = TipoModulo;
            if (ModelState.IsValid)
            {
                // -- Modifica el modulo
                module.Activo = true;
                // -- Creo el parent solo si eligió alguno
                if (ParentID != 0)
                {
                    module.Parent = new Module { EntityID = ParentID };
                }
                logic.Update(module);
                TempData["SaveSuccess"] = "Se guardó módulo correctamente";
                return RedirectToAction("Index", "Module");
            }
            // -- Si el modelo no es valido se muestra nuevamente la vista
            CargarTipoModulos(module.Type);
            ViewBag.tree = Arbol.MakeTree(ParentID);
            return View(module);
        }

        #endregion

        private void CargarTipoModulos(int tipoModulo)
        {
            var tipos = from TipoModulo s in Enum.GetValues(typeof(TipoModulo))
                        select new { ID = (int)s, Name = ToEnumString<TipoModulo>(s) };
            ViewBag.TipoModulo = new SelectList(tipos, "ID", "Name", tipoModulo);
        }
        public static string ToEnumString<T>(T type)
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }
    }
}
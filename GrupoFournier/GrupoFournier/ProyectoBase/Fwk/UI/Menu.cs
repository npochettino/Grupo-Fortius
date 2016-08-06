using Entities;
using Logic;
using Newtonsoft.Json;
using PresentacionGrupoFournier.Globales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentacionGrupoFournier.Fwk.UI
{
    public static class Menu
    {

        #region Logics

        static ModuleLogic moduleLogic;

        /// <summary>
        /// Logica de Module
        /// </summary>
        static ModuleLogic ModuleLogic
        {
            get
            {
                if (moduleLogic == null)
                {
                    moduleLogic = new ModuleLogic();
                }
                return moduleLogic;
            }
        }

        #endregion

        #region Public Methods

        #region Menu

        /// <summary>
        /// Crea el menu para los roles
        /// </summary>
        public static void CreateRolesMenu()
        {
            foreach (Rol rol in VariablesAplicacion.Roles)
            {
                var modulos = rol.Modulos;
                string menuHTML = MakeHTMLMenu(modulos.Where(x => x.Enabled && x.Activo && x.Parent == null && x.Type == ModulesType.MENU_ITEM).OrderBy(x => x.Order).ToList(), modulos.Where(x => x.Enabled).ToList());
                rol.MenuHTML = menuHTML;
            }
        }

        /// <summary>
        /// Genera el Html para el menu
        /// </summary>
        /// <param name="menuItems">Items del menu ordenados en cascada</param>
        /// <param name="profileModules">Items de menu del perfil</param>
        /// <returns></returns>
        public static string MakeHTMLMenu(List<Module> menuItems, List<Module> rolModules)
        {
            var htmlMenu = HtmlGenerator.OpenMenuClass();
            //Itero sobre los items que tenga el perfil
            foreach (Module menuItem in menuItems.Where(x => x.Parent == null && rolModules.Select(y => y.EntityID).Contains(x.EntityID)).OrderBy(x => x.Order))
            {
                MakeHTMLItem(menuItem, ref htmlMenu, rolModules);
            }

            htmlMenu += HtmlGenerator.CloseMenuClass();

            return htmlMenu;
        }

        #endregion      
       

        /// <summary>
        /// Genera el html para los hijos
        /// </summary>
        /// <param name="menuItem">item de menu</param>
        /// <param name="html">html</param>
        /// <param name="profileModules">módulos del perfil</param>
        public static void MakeHTMLItem(Module menuItem, ref string html, List<Module> rolModules)
        {
            string actions = string.Empty;
            //Agrego accion para todos los items de menu hijos que sean de tipo accion y esten en el perfil
            menuItem.Children.Where(x => x.Type == ModulesType.ACTION && rolModules.Select(y => y.EntityID).Contains(x.EntityID) && x.Activo).ToList().ForEach(x => actions += x.Action + " ");
            actions = actions.Trim();
            //Si tiene hijos para el perfil
            if (menuItem.Children.Where(x => (x.Type == ModulesType.MENU_ACTION || x.Type == ModulesType.MENU_ITEM) && rolModules.Select(y => y.EntityID).Contains(x.EntityID) && x.Activo).ToList().Count > 0)
            {
                //Etiqueta de apertura de lista
                html += HtmlGenerator.OpenParentListItem(menuItem.Action, menuItem.Icon, menuItem.Caption, actions);
                //Para cada hijo
                foreach (Module childItem in menuItem.Children.Where(x => rolModules.Select(y => y.EntityID).Contains(x.EntityID)).OrderBy(x => x.Order))
                {
                    //Creo html para el hijo
                    MakeHTMLItem(childItem, ref html, rolModules);
                }
                //Etiqueta de cierre de lista
                html += HtmlGenerator.CloseParentListItem();
            }
            else
            {
                html += HtmlGenerator.AddListItem(menuItem.Action, menuItem.Icon, menuItem.Caption, actions);
            }
        }

        #endregion
    }
}
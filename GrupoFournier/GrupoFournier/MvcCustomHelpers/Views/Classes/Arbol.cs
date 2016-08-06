using Entities;
using Logic;
using MvcCustomHelpers.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCustomHelpers.Classes
{
    public class Arbol
    {
        #region Logic

        private ModuleLogic moduleLogic;
        public ModuleLogic ModuleLogic
        {
            get
            {
                if(moduleLogic==null)
                {
                    moduleLogic = new ModuleLogic();
                }
                return moduleLogic;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Crea el arbol de seleccion y setea un elemento
        /// </summary>
        /// <param name="checkedModuleID">ID Module (Checked)</param>
        /// <returns>Json Object</returns>
        public static string MakeTree(long checkedModuleID)
        {
            var menuModules = new ModuleLogic().GetAllActivos()
                .Where(x => (x.Type == ModulesType.MENU_ACTION || x.Type == ModulesType.MENU_ITEM) && x.Parent == null).ToList();

            List<TreeNode> tree = new List<TreeNode>();

            foreach (var menuModule in menuModules.Where(x => x.Parent == null))
            {
                bool hasChildren = false;

                if (menuModule.Children != null && menuModule.Children.Where(x => x.Type == ModulesType.MENU_ACTION || x.Type == ModulesType.MENU_ITEM).ToList().Count > 0)
                {
                    hasChildren = true;
                }

                bool check = false;

                if (menuModule.EntityID == checkedModuleID)
                {
                    check = true;
                }

                TreeNode fatherNode = new TreeNode(menuModule.EntityID, menuModule.Name, true, hasChildren, false, true, check);

                if (hasChildren)
                {
                    LoadChildrens(menuModule, ref fatherNode, checkedModuleID);
                }

                tree.Add(fatherNode);
            }
            var jsonTree = JsonConvert.SerializeObject(tree, Formatting.None);

            if (!jsonTree.StartsWith("["))
            {
                jsonTree = string.Format("{0}{1}{2}", "[", jsonTree, "]");
            }

            return jsonTree;
        }

        /// <summary>
        /// Crea el arbol de seleccion para un rol
        /// </summary>
        /// <param name="profileModules">Lista de IDs Modulos</param>
        /// <returns>Json Object</returns>
        public static string MakeTree(List<Module> rolModules)
        {
            List<long> moduleIDs = GetModuleIDs(rolModules);

            var menuModules = new ModuleLogic().GetAllActivos();

            List<TreeNode> tree = new List<TreeNode>();

            foreach (var menuModule in menuModules.Where(x => x.Parent == null))
            {
                bool hasChildren = false;

                if (menuModule.Children != null && menuModule.Children.Count > 0)
                {
                    hasChildren = true;
                }

                bool check = false;

                if (moduleIDs.Contains(menuModule.EntityID))
                {
                    check = true;
                }

                string label = menuModule.Name;

                if (menuModule.Type == ModulesType.ACTION)
                {
                    label = string.Format("{0}{1}", label, "<i></i>");
                }

                TreeNode fatherNode = new TreeNode(menuModule.EntityID, label, true, hasChildren, true, false, check);

                if (hasChildren)
                {
                    LoadChildrens(menuModule, ref fatherNode, moduleIDs);
                }

                tree.Add(fatherNode);
            }

            var jsonTree = JsonConvert.SerializeObject(tree, Formatting.None);

            if (!jsonTree.StartsWith("["))
            {
                jsonTree = string.Format("{0}{1}{2}", "[", jsonTree, "]");
            }

            return jsonTree;
        }

        /// <summary>
        /// Carga los hijos en el arbol y setea un checkeado
        /// </summary>
        /// <param name="menuModule">Module</param>
        /// <param name="fatherNode">TreeNode</param>
        /// <param name="checkedModuleID">ID Module (Checked)</param>
        public static void LoadChildrens(Module menuModule, ref TreeNode fatherNode, long checkedModuleID)
        {
            foreach (Module childMenuModule in menuModule.Children.Where(x => x.Type == ModulesType.MENU_ACTION || x.Type == ModulesType.MENU_ITEM))
            {
                bool hasChildren = false;

                if (childMenuModule.Children != null && childMenuModule.Children.Where(x => x.Type == ModulesType.MENU_ACTION || x.Type == ModulesType.MENU_ITEM).ToList().Count > 0)
                {
                    hasChildren = true;
                }

                bool check = false;

                if (childMenuModule.EntityID == checkedModuleID)
                {
                    check = true;
                }

                TreeNode childNode = new TreeNode(childMenuModule.EntityID, childMenuModule.Name, true, hasChildren, false, true, check);

                if (hasChildren)
                {
                    LoadChildrens(childMenuModule, ref childNode, checkedModuleID);
                }

                fatherNode.branch.Add(childNode);
            }
        }

        /// <summary>
        /// Carga los hijos en el arbol y setea varios checkeados
        /// </summary>
        /// <param name="menuModule">Module</param>
        /// <param name="fatherNode">TreeNode</param>
        /// <param name="moduleIDs">Lista de ID Modulos</param>
        public static void LoadChildrens(Module menuModule, ref TreeNode fatherNode, List<long> moduleIDs)
        {
            foreach (Module childMenuModule in menuModule.Children)
            {
                bool hasChildren = false;
                if (childMenuModule.Children != null && childMenuModule.Children.Count > 0)
                {
                    hasChildren = true;
                }
                bool check = false;
                if (moduleIDs.Contains(childMenuModule.EntityID))
                {
                    check = true;
                }
                string label = childMenuModule.Name;
                if (childMenuModule.Type == ModulesType.ACTION)
                {
                    label = string.Format("{0}{1}", label, "<i></i>");
                }
                TreeNode childNode = new TreeNode(childMenuModule.EntityID, label, true, hasChildren, true, false, check);
                if (hasChildren)
                {
                    LoadChildrens(childMenuModule, ref childNode, moduleIDs);
                }
                fatherNode.branch.Add(childNode);
            }
        }

        /// <summary>
        /// Obtiene id de modulos para un rol
        /// </summary>
        /// <param name="profileModule">Lista de ID Perfiles</param>
        /// <returns>Lista de ID Modulos</returns>
        private static List<long> GetModuleIDs(List<Module> rolModules)
        {
            List<long> ids = new List<long>();
            foreach (Module module in rolModules)
            {
                ids.Add(module.EntityID);
            }
            return ids;
        }

        #endregion
    }
}
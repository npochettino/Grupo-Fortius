using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PresentacionGrupoFournier.Fwk.UI
{
    /// <summary>
    /// HtmlCodeGenerator -> Helper para generar tags y codigo html
    /// </summary>
    public static class HtmlGenerator
    {
        #region Members

        /// <summary>
        /// HtmlBuilder member
        /// </summary>
        private static StringBuilder htmlBuilder;

        #endregion

        #region Properties

        /// <summary>
        /// StringBuilder accessor
        /// </summary>
        private static StringBuilder HtmlBuilder
        {
            get
            {
                if (htmlBuilder == null)
                    htmlBuilder = new StringBuilder();
                return htmlBuilder;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Agrega un list item
        /// </summary>
        /// <param name="url"></param>
        /// <param name="icon"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string AddListItem(string url, string icon, string description, string actions)
        {
            HtmlBuilder.Clear();

            HtmlBuilder.Append("<li>");
            if (actions != string.Empty)
            {
                HtmlBuilder.AppendFormat("<a href='{0}' data-children-actions='{1}'>", url, actions);
            }
            else
            {
                HtmlBuilder.AppendFormat("<a href='{0}'>", url);
            }
            HtmlBuilder.AppendFormat("<i class='{0}'></i>", icon);
            HtmlBuilder.AppendFormat("<span>{0}</span>", description);
            HtmlBuilder.Append("</a>");
            HtmlBuilder.Append("</li>");

            return HtmlBuilder.ToString();
        }

        /// <summary>
        /// Abre una lista de items hijos
        /// </summary>
        /// <param name="url"></param>
        /// <param name="icon"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static string OpenParentListItem(string url, string icon, string description, string actions)
        {
            HtmlBuilder.Clear();

            HtmlBuilder.Append("<li class='treeview'>");
            if (actions != string.Empty)
            {
                HtmlBuilder.AppendFormat("<a href='{0}' data-children-actions='{1}'>", url, actions);
            }
            else
            {
                HtmlBuilder.AppendFormat("<a href='{0}'>", url);
            }
            HtmlBuilder.AppendFormat("<i class='{0}'></i>", icon);
            HtmlBuilder.AppendFormat("<span>{0}</span>", description);
            HtmlBuilder.Append("<i class='fa fa-angle-left pull-right'></i>");
            HtmlBuilder.Append("</a>");
            HtmlBuilder.Append("<ul class='treeview-menu'>");

            return HtmlBuilder.ToString();
        }

        /// <summary>
        /// Cierra la lista de items hijos
        /// </summary>
        /// <returns>"/ul/li"</returns>
        public static string CloseParentListItem()
        {
            HtmlBuilder.Clear();
            HtmlBuilder.Append("</ul></li>");
            return HtmlBuilder.ToString();
        }

        /// <summary>
        /// Setea la clase css para el menú
        /// </summary>
        /// <returns></returns>
        public static string OpenMenuClass()
        {
            HtmlBuilder.Clear();
            HtmlBuilder.Append("<ul class=\"sidebar-menu\"><li class=\"header\"></li>");
            return HtmlBuilder.ToString();
        }

        /// <summary>
        /// Cierra la clase css para el menú
        /// </summary>
        /// <returns></returns>
        public static string CloseMenuClass()
        {
            HtmlBuilder.Clear();
            HtmlBuilder.Append("</ul>");
            return HtmlBuilder.ToString();
        }
        #endregion
    }
}
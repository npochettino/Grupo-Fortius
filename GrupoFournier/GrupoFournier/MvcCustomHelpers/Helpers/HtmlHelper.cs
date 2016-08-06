using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace MvcCustomHelpers.Generic
{
    public static class HtmlHelpers
    {
        /// <summary>
        /// Genera script para hacer foco en el campo enviado por parametro.
        /// </summary>
        /// <param name="">Campo del modelo donde se va a hacer foco</param>
        /// <returns>Script SetFocus</returns>
        public static MvcHtmlString SetFocusTo<TModel, TProperty>(
                        this HtmlHelper<TModel> html,
                        Expression<Func<TModel, TProperty>> expression)
        {
            var prop = ExpressionHelper.GetExpressionText(expression);
            return html.setFocusTo(prop);
        }

        /// <summary>
        /// Genera script para hacer foco en el campo enviado por parametro.
        /// </summary>
        /// <param name="">Campo string seteado como parametro</param>
        /// <returns>Script SetFocus</returns>
        public static MvcHtmlString SetFocusTo(this HtmlHelper html,
                                               string propertyName)
        {
            var prop = ExpressionHelper.GetExpressionText(propertyName);
            return html.setFocusTo(prop);
        }

        /// <summary>
        /// Metodo que genera el script para setear foco.
        /// </summary>
        /// <param name="">Campo</param>
        /// <returns>Script SetFocus</returns>
        private static MvcHtmlString setFocusTo(this HtmlHelper html,
                                                string property)
        {
            string id = html.ViewData.TemplateInfo.GetFullHtmlFieldId(property);

            var script = "<script>" +
                            "$(document).ready(function() {" +
                                "$('#" + id + "').focus();" +
                            "});" +
                            "</script>";
            return MvcHtmlString.Create(script);
        }

    }
}
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcCustomHelpers.Generic
{
    public static class InputsHelpersForModels
    {
        /// <summary>
        /// Arma un input con mask de numerico para una propiedad del modelo
        /// </summary>
        /// <typeparam name="TModel">Modelo</typeparam>
        /// <typeparam name="TValue">Propiedad</typeparam>
        /// <param name="helper">Html helper</param>
        /// <param name="expression">expression de la propiedad</param>
        /// <param name="ID">ID para el control</param>
        /// <param name="enteros">cantidad de enteros</param>
        /// <param name="decimales">cantidad decimales</param>
        /// <returns></returns>
        public static MvcHtmlString InputMaskNumeric<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string ID, int enteros, int decimales)
        where TModel : class, IEntityBase
        {
            // -- Creo string builder
            StringBuilder sb = new StringBuilder();
            // -- Abro etiqueta script
            sb.Append("<script>");
            // -- Creo objeto del control actual
            sb.Append("var nuevoControlInputMaskNumerico = { id: '" + ID + "', enteros: " + enteros + ", decimales: " + decimales + "};");
            // -- Agrego el objeto al array
            sb.Append("inputsMaskNumericos.push(nuevoControlInputMaskNumerico);");
            // -- Cierro etiqueta script
            sb.Append("</script>");
            // -- Creo el control
            sb.Append(helper.EditorFor(expression, new { htmlAttributes = new { @class = "form-control input-mask-numeric-control" } }).ToString());
            // -- Devuelvo
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Arma un input con mask de numerico para una propiedad del modelo
        /// </summary>
        /// <typeparam name="TModel">Modelo</typeparam>
        /// <typeparam name="TValue">Propiedad</typeparam>
        /// <param name="helper">Html helper</param>
        /// <param name="expression">expression de la propiedad</param>
        /// <param name="ID">ID para el control</param>
        /// <param name="enteros">cantidad de enteros</param>
        /// <param name="decimales">cantidad decimales</param>
        /// <returns></returns>
        public static MvcHtmlString InputMaskNumericMoney<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string ID, int enteros, int decimales)
        where TModel : class, IEntityBase
        {
            // -- Creo string builder
            StringBuilder sb = new StringBuilder();
            // -- Abro etiqueta script
            sb.Append("<script>");
            // -- Creo objeto del control actual
            sb.Append("var nuevoControlInputMaskNumerico = { id: '" + ID + "', enteros: " + enteros + ", decimales: " + decimales + "};");
            // -- Agrego el objeto al array
            sb.Append("inputsMaskNumericos.push(nuevoControlInputMaskNumerico);");
            // -- Cierro etiqueta script
            sb.Append("</script>");
            // -- Abro contenedores
            sb.Append("<div class=\"input-group\">");
            // -- Creo el control
            sb.Append(helper.EditorFor(expression, new { htmlAttributes = new { @class = "form-control input-mask-numeric-control" } }).ToString());
            // -- Icono y cierre etiquetas
            sb.Append("<div class=\"input-group-addon\"><i class=\"fa fa-fw fa-dollar\"></i></div></div>");
            // -- Devuelvo
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Armo un input date para una propiedad de un modelo
        /// </summary>
        /// <typeparam name="TModel">Modelo</typeparam>
        /// <typeparam name="TValue">Propiedad</typeparam>
        /// <param name="helper">Html helper</param>
        /// <param name="expression">expression para la propiedad</param>
        /// <param name="valorFecha">valor de la fecha en formato date</param>
        /// <returns></returns>
        public static MvcHtmlString InputDate<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, DateTime? valorFecha)
        {
            // -- Creo string builder
            StringBuilder sb = new StringBuilder();
            // -- Abro contenedores
            sb.Append("<div class=\"span5 col-md-5 sandbox-container-datepicker form-control\"><div class=\"input-group date\">");
            // -- Creo el control dependiendo si la fecha es vacia o no
            if (valorFecha != null)
            {
                // -- Creo control y seteo fecha
                sb.Append(helper.TextBoxFor(expression, new { @Value = valorFecha.Value.ToString("dd/MM/yyyy") }));
            }
            else
            {
                // -- Creo control
                sb.Append(helper.TextBoxFor(expression));
            }
            //sb.Append("<input id=\"FechaEmision\" name=\"FechaEmision\" class=\"input-mask-numeric-control\" />");
            // -- Agrego imagen
            sb.Append("<span class=\"input-group-addon\"><i class=\"fa fa-fw fa-calendar\"></i></span>");
            // -- Cierro contenedores
            sb.Append("</div></div>");
            // -- Devuelvo
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Armo un input datetime para una propiedad de un modelo
        /// </summary>
        /// <typeparam name="TModel">Modelo</typeparam>
        /// <typeparam name="TValue">Propiedad</typeparam>
        /// <param name="helper">Html helper</param>
        /// <param name="expression">expression para la propiedad</param>
        /// <param name="valorFecha">valor de la fecha en formato date</param>
        /// <returns></returns>
        public static MvcHtmlString InputDateTime<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, DateTime? valorFecha)
        {
            // -- Creo string builder
            StringBuilder sb = new StringBuilder();
            // -- Abro contenedores
            sb.Append("<div class=\"span5 col-md-5 sandbox-container-datetimepicker form-control\"><div class=\"input-group date\">");
            // -- Creo el control dependiendo si la fecha es vacia o no
            if (valorFecha != null)
            {
                // -- Creo control y seteo fecha
                sb.Append(helper.TextBoxFor(expression, new { @Value = valorFecha.Value.ToString("dd/MM/yyyy HH:mm"), @class = "form-control datetimepicker-control" }));
            }
            else
            {
                // -- Creo control
                sb.Append(helper.TextBoxFor(expression, new { @class = "form-control datetimepicker-control" }));
            }
            // -- Agrego imagen
            sb.Append("<span class=\"input-group-addon\"><i class=\"fa fa-fw fa-calendar\"></i></span>");
            // -- Cierro contenedores
            sb.Append("</div></div>");
            // -- Devuelvo
            return new MvcHtmlString(sb.ToString());
        }

        /// <summary>
        /// Arma un input con mask de numerico para una propiedad del modelo
        /// </summary>
        /// <typeparam name="TModel">Modelo</typeparam>
        /// <typeparam name="TValue">Propiedad</typeparam>
        /// <param name="helper">Html helper</param>
        /// <param name="expression">expression de la propiedad</param>
        /// <param name="ID">ID para el control</param>
        /// <param name="enteros">cantidad de enteros</param>
        /// <param name="decimales">cantidad decimales</param>
        /// <returns></returns>
        public static MvcHtmlString InputPassword<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        where TModel : class, IEntityBase
        {
            // -- Creo string builder
            StringBuilder sb = new StringBuilder();
            // -- Abro contenedores
            sb.Append("<div class=\"input-group\">");
            // -- Creo el control
            sb.Append(helper.PasswordFor(expression, htmlAttributes: new { @class = "form-control" }).ToString());
            // -- Icono y cierre etiquetas
            sb.Append("<div class=\"input-group-addon\"><i class=\"fa fa-fw fa-lock\"></i></div></div>");
            // -- Devuelvo
            return new MvcHtmlString(sb.ToString());
        }

        public static MvcHtmlString InputText<TModel, TValue>(System.Web.Mvc.HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string iconClass)
        where TModel : class, IEntityBase
        {
            // -- Creo string builder
            StringBuilder sb = new StringBuilder();
            // -- Abro contenedores
            sb.Append("<div class=\"input-group\">");
            // -- Creo el control
            sb.Append(helper.EditorFor(expression, new { htmlAttributes = new { @class = "form-control" } }).ToString());
            // -- Icono y cierre etiquetas
            sb.Append("<div class=\"input-group-addon\"><i class=\"" + iconClass + "\"></i></div></div>");
            // -- Devuelvo
            return new MvcHtmlString(sb.ToString());
        }
    }
}
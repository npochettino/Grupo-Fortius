using Entities;
using MvcCustomHelpers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcCustomHelpers.Helpers
{
    public static class BusquedaHelperGeneric
    {
        public static MvcHtmlString ControlBusqueda<T>(string id, string action, string nameProp, string hiddenText, string descriptionText, List<ControlBusquedaParametros> parametrosFiltro = null)
        where T : class, IEntityBase
        {
            // -- Creo el string builder
            StringBuilder sb = new StringBuilder();
            // -- Agrego el boton 
            sb.Append(String.Format("<a class=\"btn btn-danger btn-md\" onclick=\"mostrarModalBusqueda('modal-{0}', 'search-table-{0}', '{1}', '{2}', 'input-search-{0}', '{0}', '{3}', '{4}')\"><i class=\"fa fa-search\"></i></a>", id, action, nameProp, hiddenText, descriptionText));
            // -- Html para el modal
            sb.Append(String.Format("<div id=\"modal-{0}\" class=\"modal fade modalTablaBusqueda\" role=\"dialog\">", id));
            sb.Append("<div class=\"modal-dialog\">");
            sb.Append("<div class=\"modal-content\">");
            sb.Append("<div class=\"modal-header\">");
            sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"modal\">&times;</button>");
            sb.Append("<h4 class=\"modal-title\">Búsqueda</h4>");
            sb.Append("</div>");
            sb.Append("<div class=\"modal-body\">");
            // -- Input de text para filtrar
            sb.Append(String.Format("<input class=\"form-control textBuscar\" id=\"input-search-{0}\" placeholder=\"Escriba para buscar...\" type=\"text\">", id));
            sb.Append("<div style=\"margin-top:50px\">");
            // -- Tabla que implementa jquery dataTables
            sb.Append(String.Format("<table id=\"search-table-{0}\" class=\"tablaBusqueda table table-bordered table-striped\">", id));
            sb.Append("<thead>");
            // -- th para EntityID
            sb.Append("<th>EntityID</th>");

            // -- Instancio lista de columnas del control
            List<ControlBusquedaColumna> columnas = new List<ControlBusquedaColumna>();

            // -- Por cada propiedad de la entidad
            foreach (PropertyInfo prop in typeof(T).GetProperties())
            {
                // -- Obtengo atributos
                object[] attrs = prop.GetCustomAttributes(true);
                // -- Por cada atributo
                foreach (object attr in attrs)
                {
                    // -- Lo convierto al tipo de atributo del control de busqueda
                    ControlBusquedaAttribute ctrlBusquedaAttr = attr as ControlBusquedaAttribute;
                    if (ctrlBusquedaAttr != null)
                    {
                        // -- Obtengo propiedad titulo del atributo
                        string titulo = ctrlBusquedaAttr.Titulo;
                        // -- Obtengo propiedad orden del atributo
                        int orden = ctrlBusquedaAttr.Orden;
                        // -- Obtengo nombre de la propiedad
                        string propertyName = prop.Name;

                        // -- Creo una columna
                        ControlBusquedaColumna columna = new ControlBusquedaColumna { Propiedad = propertyName, Titulo = titulo, Orden = orden };
                        // -- Agrego la columna
                        columnas.Add(columna);
                    }
                }
            }

            // -- Por cada columna
            foreach (ControlBusquedaColumna columna in columnas.OrderBy(c => c.Orden))
            {
                // -- Agrego el th
                sb.Append(String.Format("<th>{0}</th>", columna.Propiedad));
            }

            // -- Cierro tags abiertas (th vacio para botones)
            sb.Append("<th></th></thead></table></div></div>");
            sb.Append("<div class=\"modal-footer\"><button type=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Cerrar</button></div></div></div></div>");

            // -- Etiqueta scripts
            sb.Append("<script>");
            // -- Array de columnas
            sb.Append("var columnasActuales = [];");
            // -- Columa para entityID
            sb.Append("columnasActuales.push({ 'data': 'EntityID', 'visible': false });");

            // -- Por cada columna
            foreach (ControlBusquedaColumna columna in columnas.OrderBy(c => c.Orden))
            {
                // -- Agrego una columna al array de js
                sb.Append("columnasActuales.push({ 'data': '" + columna.Propiedad + "', 'title': '" + columna.Titulo + "' });");
            }

            sb.Append("var obj = [];");
            sb.Append(String.Format("obj.push('{0}');", id));
            sb.Append("obj.push(columnasActuales);");
            sb.Append("columns.push(obj);");
            sb.Append("");

            sb.Append("var reload = [];");
            sb.Append(String.Format("reload.push('{0}');", id));
            sb.Append("reload.push(false);");
            sb.Append("reloades.push(reload);");

            // -- Si tiene parametros
            if (parametrosFiltro != null)
            {
                // -- Creo el array js
                sb.Append("var params = [];");
                // -- Por cada parametro
                foreach (ControlBusquedaParametros param in parametrosFiltro)
                {
                    // -- Lo agrego al array
                    sb.Append(String.Format("params.push(['{0}', '{1}']);", param.Tipo, param.ID));
                }
                // -- Agrego al array global
                sb.Append(String.Format("parametrosFiltro.push(['{0}', params]);", id));
            }

            sb.Append("</script>");

            return new MvcHtmlString(sb.ToString());
        }
    }
}
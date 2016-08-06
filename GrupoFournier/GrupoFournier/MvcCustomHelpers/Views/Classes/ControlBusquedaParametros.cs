using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCustomHelpers.Classes
{
    public class ControlBusquedaParametros
    {
        #region Miembros

        private string tipo;
        private string id;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de la columna de la entidad que se usa en el control de busqueda
        /// </summary>
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /// <summary>
        /// Titulo para la columna de control de busqueda
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        #endregion
    }
}
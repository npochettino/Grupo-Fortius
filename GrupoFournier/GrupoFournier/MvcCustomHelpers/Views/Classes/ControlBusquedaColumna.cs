using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCustomHelpers.Classes
{
    public class ControlBusquedaColumna
    {

        #region Miembros

        private string propiedad;
        private string titulo;
        private int orden;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad de la columna de la entidad que se usa en el control de busqueda
        /// </summary>
        public string Propiedad
        {
            get { return propiedad; }
            set { propiedad = value; }
        }

        /// <summary>
        /// Titulo para la columna de control de busqueda
        /// </summary>
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        /// <summary>
        /// Orden de la columna
        /// </summary>
        public int Orden
        {
            get
            {
                return orden;
            }
            set
            {
                orden = value;
            }
        }

        #endregion



    }
}
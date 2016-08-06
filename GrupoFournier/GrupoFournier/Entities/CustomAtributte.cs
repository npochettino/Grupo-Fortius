using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ControlBusquedaAttribute : Attribute
    {

        /// <summary>
        /// Titulo para la columna
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Orden que tendra la propiedad entre las columnas en el buscador
        /// </summary>
        public int Orden { get; set; }
    }
}

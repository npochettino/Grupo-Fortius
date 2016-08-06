using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.Common
{
    public class ParameterProvider
    {
        /// <summary>
        /// Enumeracion de Tipos de Plantillas
        /// </summary>
        public sealed class TipoPlantilla
        {
            /// <summary>
            /// Plantilla Botones
            /// </summary>
            public const int Botones = 1;

            /// <summary>
            /// Plantilla Textos centrados
            /// </summary>
            public const int TextosCentrados = 2;

            /// <summary>
            /// Plantilla Textos en diferentes posiciones
            /// </summary>
            public const int TextosDiferentesPosiciones = 3;

            /// <summary>
            /// Plantilla Textos apilados horizontalmente
            /// </summary>
            public const int TextosApiladosHorizontal = 4;

            /// <summary>
            /// Plantilla Video
            /// </summary>
            public const int Video = 5;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DiapositivaVM
    {
        public DiapositivaVM()
        {
            ColorBoton1 = "#000000";
            ColorBoton2 = "#000000";
            ColorBoton3 = "#000000";
            ColorBoton4 = "#000000";
            ColorBoton5 = "#000000";
        }

        public Diapositiva Diapositiva { get; set; }

        #region Botones

        public string TituloBoton1 { get; set; }
        public string ContenidoBoton1 { get; set; }
        public string ColorBoton1 { get; set; }
        public string AudioBoton1 { get; set; }

        public string TituloBoton2 { get; set; }
        public string ContenidoBoton2 { get; set; }
        public string ColorBoton2 { get; set; }

        public string TituloBoton3 { get; set; }
        public string ContenidoBoton3 { get; set; }
        public string ColorBoton3 { get; set; }

        public string TituloBoton4 { get; set; }
        public string ContenidoBoton4 { get; set; }
        public string ColorBoton4 { get; set; }

        public string TituloBoton5 { get; set; }
        public string ContenidoBoton5 { get; set; }
        public string ColorBoton5 { get; set; }

        #endregion

        #region Textos centrados y horizontales

        public string TextoAlineado1 { get; set; }
        public string TextoAlineado2 { get; set; }
        public string TextoAlineado3 { get; set; }
        public string TextoAlineado4 { get; set; }
        public string TextoAlineado5 { get; set; }

        #endregion

        #region Textos distribuidos

        public string TextoDistribuido1 { get; set; }
        public string TextoDistribuido2 { get; set; }
        public string TextoDistribuido3 { get; set; }
        public string TextoDistribuido4 { get; set; }
        public string TextoDistribuido5 { get; set; }

        #endregion

        #region Video

        public string Video { get; set; }

        #endregion
    }
}

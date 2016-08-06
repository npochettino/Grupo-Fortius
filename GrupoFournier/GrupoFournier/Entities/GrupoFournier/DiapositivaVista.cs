using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.GrupoFournier
{
    public class DiapositivaVista : EntityBase
    {
        /// <summary>
        /// Diapositiva vista
        /// </summary>
        public virtual Diapositiva Diapositiva { get; set; }

        /// <summary>
        /// Fecha y hora de la ultima vez que vio la diapositiva
        /// </summary>
        public virtual DateTime FechaHoraVista { get; set; }

        /// <summary>
        /// Usuario que vio la diapositva
        /// </summary>
        public virtual Usuario Usuario { get; set; }
    }
}

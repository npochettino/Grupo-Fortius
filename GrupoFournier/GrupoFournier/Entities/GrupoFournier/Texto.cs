using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Texto : EntityBase
    {
        public virtual string Contenido { get; set; }

        public virtual int Orden { get; set; }

        public virtual string Audio { get; set; }
        
        //Indica el segundo en el que arranca este audio
        public virtual double TiempoDeArranque { get; set; }
    }
}

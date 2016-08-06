using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Boton : EntityBase
    {
        public virtual string Nombre { get; set; }

        public virtual string Contenido { get; set; }

        public virtual string Color { get; set; }

        public virtual int Orden { get; set; }

        public virtual string Audio { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Plantilla : EntityBase
    {
        public virtual string Nombre { get; set; }

        public virtual string Estructura { get; set; }
    }
}

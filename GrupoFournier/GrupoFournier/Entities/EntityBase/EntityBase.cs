using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityBase : IEntityBase
    {
        public virtual long EntityID
        {
            get;
            set;
        }
        public virtual bool Activo
        {
            get;
            set;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Interface para entity base
    /// </summary>
    public interface IEntityBase
    {
        long EntityID { get; set; }
        bool Activo { get; set; }
    }
}

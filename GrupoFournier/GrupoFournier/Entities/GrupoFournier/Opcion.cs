using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Opcion : EntityBase
    {
        [Required(ErrorMessage = "La descripcion es requerida")]
        /// <summary>
        /// Descripcion
        /// </summary>
        public virtual string Descripcion { get; set; }

        /// <summary>
        /// Si es la respuesta correcta
        /// </summary>
        public virtual bool Correcta { get; set; }

        /// <summary>
        /// Pregunta asociada
        /// </summary>
        public virtual Pregunta Pregunta { get; set; }
    }
}

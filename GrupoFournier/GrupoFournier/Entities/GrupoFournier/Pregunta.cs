using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pregunta : EntityBase
    {
        public Pregunta()
        {
            Opciones = new List<Opcion>();
        }

        [Required(ErrorMessage = "El titulo es requerido")]
        /// <summary>
        /// Titulo
        /// </summary>
        public virtual string Titulo { get; set; }

        [Required(ErrorMessage = "El orden es requerido")]
        [Display(Name = "Orden")]
        [Range(1, 1000, ErrorMessage = "El orden debe estar entre 1 y 1000")]
        /// <summary>
        /// Orden
        /// </summary>
        public virtual int Orden { get; set; }

        /// <summary>
        /// Opciones de la pregunta
        /// </summary>
        public virtual IList<Opcion> Opciones { get; set; }

        /// <summary>
        /// Curso asociado
        /// </summary>
        public virtual Curso Curso { get; set; }
    }
}

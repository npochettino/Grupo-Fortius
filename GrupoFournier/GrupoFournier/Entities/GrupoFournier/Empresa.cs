using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Empresa : EntityBase
    {
        public Empresa()
        {
            EmpresaCursos = new List<EmpresaCurso>();
        }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres")]
        /// <summary>
        /// Nombre de la empresa
        /// </summary>
        public virtual string Nombre { get; set; }

        ///// <summary>
        ///// Cursos
        ///// </summary>
        //public virtual IList<Curso> Cursos { get; set; }

        /// <summary>
        /// Cursos de la empresa
        /// </summary>
        public virtual IList<EmpresaCurso> EmpresaCursos { get; set; }

        /// <summary>
        /// Imagen
        /// </summary>
        public virtual string Imagen { get; set; }
    }
}

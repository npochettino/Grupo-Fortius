using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EmpresaCurso : EntityBase
    {
        /// <summary>
        /// Curso
        /// </summary>
        public virtual Curso Curso { get; set; }

        /// <summary>
        /// Si tiene limite de tiempo
        /// </summary>
        /// 
        [Display(Name = "Limite")]
        public virtual bool TieneLimite { get; set; }

        /// <summary>
        /// Fecha hasta de vigencia
        /// </summary>
        /// 
        [Display(Name = "Fecha Hasta")]
        public virtual DateTime? FechaHasta { get; set; }
    }
}

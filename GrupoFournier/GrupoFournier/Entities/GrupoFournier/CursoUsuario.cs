using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CursoUsuario : EntityBase
    {
        /// <summary>
        /// Nota del curso
        /// </summary>
        public virtual float Nota { get; set; }

        /// <summary>
        /// Usuario 
        /// </summary>
        public virtual Usuario Usuario { get; set; }

        /// <summary>
        /// Curso
        /// </summary>
        public virtual Curso Curso { get; set; }

        /// <summary>
        /// Estado del curso para el usuario
        /// </summary>
        public virtual EstadoCurso EstadoCurso { get; set; }
    }
}

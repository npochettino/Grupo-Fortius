using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Curso : EntityBase
    {
        public Curso()
        {
            Preguntas = new List<Pregunta>();
        }
        /// <summary>
        /// Nombre del curso
        /// </summary>
        /// 
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El nombre no debe superar los 100 caracteres")]
        public virtual string Nombre { get; set; }

        /// <summary>
        /// Descripcion del curso
        /// </summary>        
        /// 
        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(250, ErrorMessage = "La descripcion no debe superar los 250 caracteres")]
        public virtual string Descripcion { get; set; }

        /// <summary>
        /// Carpeta donde esta el curso
        /// </summary>
        public virtual string FilesFolder { get; set; }

        /// <summary>
        /// Rol minimo para ver el curso
        /// </summary>        
        public virtual Rol RolMinimo { get; set; }

        /// <summary>
        /// Fecha de alta del curso
        /// </summary>        
        public virtual DateTime FechaAlta { get; set; }

        /// <summary>
        /// Si los archivos se subieron correctamente
        /// </summary>
        public virtual bool Cargado { get; set; }

        /// <summary>
        /// Nombre del index HTML del curso
        /// </summary>
        [Display(Name = "Nombre el HTML")]
        [MaxLength(250, ErrorMessage = "El nombre del HTML no debe superar los 250 caracteres")]
        public virtual string Html { get; set; }

        /// <summary>
        /// Preguntas que contiene el Curso
        /// </summary>
        public virtual IList<Pregunta> Preguntas { get; set; }
        
        /// <summary>
        /// Imagen asociada al curso
        /// </summary>
        public virtual string Imagen { get; set; }

        /// <summary>
        /// Empresa
        /// </summary>
        public virtual Empresa Empresa { get; set; }
    }
}

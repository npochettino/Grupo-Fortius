using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Diapositiva : EntityBase
    {
        public Diapositiva()
        {
            DiapositivasReferidas = new List<Diapositiva>();
            Botones = new List<Boton>();
            Textos = new List<Texto>();
        }

        /// <summary>
        /// Orden de la diapositiva en el curso
        /// </summary>
        [Required(ErrorMessage = "El orden es requerido")]
        [Range(1, 1000, ErrorMessage = "El orden debe estar entre 1 y 1000")]
        public virtual int Orden { get; set; }

        /// <summary>
        /// Título de la diapositiva
        /// </summary>
        [Required(ErrorMessage = "El título es requerido")]
        [MaxLength(250, ErrorMessage = "El título no debe superar los 250 caracteres")]
        [Display(Name = "Titulo")]
        public virtual string Titulo { get; set; }

        [Display(Name = "Color Titulo")]
        public virtual string ColorTitulo { get; set; }
       
        /// <summary>
        /// 
        /// </summary>
        public virtual Curso Curso { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual IList<Diapositiva> DiapositivasReferidas { get; set; }

        /// <summary>
        /// Imagen asociada a la diapositiva
        /// </summary>
        public virtual string Imagen { get; set; }

        /// <summary>
        /// Botones asociados a la diapositiva (Plantilla botones)
        /// </summary>
        public virtual IList<Boton> Botones { get; set; }

        /// <summary>
        /// Textos asociados a la diapositiva (Plantillas con textos)
        /// </summary>
        public virtual IList<Texto> Textos { get; set; }

        /// <summary>
        /// Video asociado a la diapositiva (Plantilla video)
        /// </summary>
        public virtual string Video { get; set; }

        /// <summary>
        /// Indica si la diapositiva es de audio o de responsive voice
        /// </summary>
        public virtual bool IsDiapositivaAudio { get; set; }

        /// <summary>
        /// Indica el tiempo total de la diapositiva
        /// </summary>
        public virtual double TiempoTotal { get; set; }

        /// <summary>
        /// Plantilla asociada a la diapositiva
        /// </summary>
        [Display(Name = "Plantilla")]
        public virtual Plantilla Plantilla { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Tipo de Usuario
    /// </summary>
    public class Rol : EntityBase
    {
        #region Members

        private string nombre;
        private IList<Module> modulos;
        private int nivel;

        #endregion

        #region Propiedades

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        [Display(Name = "Nombre")]
        /// <summary>
        /// Nombre del rol
        /// </summary>
        public virtual string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        /// <summary>
        /// Modulos del rol
        /// </summary>
        public virtual IList<Module> Modulos
        {
            get
            {
                return modulos;
            }
            set
            {
                modulos = value;
            }
        }

        /// <summary>
        /// Nivel que determina la jerarquia de un rol/ tipo de usuario
        /// </summary>
        /// 
        [Required(ErrorMessage = "El nivel es requerido")]
        [Range(0, 200, ErrorMessage = "El nivel debe estar entre 0 y 200")]
        [Display(Name = "Nivel")]
        public virtual int Nivel
        {
            get
            {
                return nivel;
            }
            set
            {
                nivel = value;
            }
        }

        #endregion

        #region Propiedades No Mapeadas

        public virtual string MenuHTML { get; set; }

        #endregion
    }
}

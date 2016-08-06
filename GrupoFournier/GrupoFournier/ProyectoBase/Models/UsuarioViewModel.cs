using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PresentacionGrupoFournier.Models
{
    public class UsuarioViewModel
    {
        #region Propiedades

        [Required(ErrorMessage = "El usuario es requerido")]
        [Display(Name = "Usuario")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        #endregion
    }
}
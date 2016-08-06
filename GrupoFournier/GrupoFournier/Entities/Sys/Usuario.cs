using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Usuario : EntityBase
    {

        #region Miembros

        private string nombreUsuario;
        private string password;
        private string nombreCompleto;
        private string mail;
        private Rol rol;
        private bool habilitado;
        private string newPassword;
        private string newPasswordRepeat;
        private bool isMailCursoTerminado;
        private Empresa empresa;

        #endregion

        #region Propiedades

        [Required(ErrorMessage = "El usuario es requerido")]
        [Display(Name = "Usuario")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "El usuario debe tener entre 6 y 50 caracteres")]
        //[RegularExpression(@"^([a-zA-Z])[a-zA-Z_-]*[\w_-]*[\S]$|^([a-zA-Z])[0-9_-]*[\S]$|^[a-zA-Z]*[\S]$", ErrorMessage = "Ingrese un nombre de usuario válido")]
        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public virtual string NombreUsuario
        {
            get
            {
                return nombreUsuario;
            }
            set
            {
                nombreUsuario = value;
            }
        }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(250, ErrorMessage = "La contraseña no puede superar los 250 caracteres")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?!.*(.)\1\1)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)([a-zA-Z0-9_-]{6,})$", ErrorMessage = "La contraseña debe superar los 6 dígitos y debe incluir una maýuscula, una minúscula y un número")]
        /// <summary>
        /// Password
        /// </summary>
        public virtual string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        [Required(ErrorMessage = "El nombre completo es requerido")]
        [StringLength(250, ErrorMessage = "El nombre completo no puede superar los 250 caracteres")]
        [Display(Name = "Nombre completo")]
        /// <summary>
        /// Nombre completo
        /// </summary>
        public virtual string NombreCompleto
        {
            get
            {
                return nombreCompleto;
            }
            set
            {
                nombreCompleto = value;
            }
        }

        [StringLength(250, ErrorMessage = "El mail no puede superar los 250 caracteres")]
        [EmailAddress(ErrorMessage = "Ingrese un mail válido")]
        [Display(Name = "Mail")]
        /// <summary>
        /// Mail
        /// </summary>
        public virtual string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                mail = value;
            }
        }

        /// <summary>
        /// Rol
        /// </summary>
        /// 
        [Display(Name= "Rol")]
        public virtual Rol Rol
        {
            get
            {
                return rol;
            }
            set
            {
                rol = value;
            }
        }

        /// <summary>
        /// Habilitado
        /// </summary>
        public virtual bool Habilitado
        {
            get
            {
                return habilitado;
            }
            set
            {
                habilitado = value;
            }
        }


        /// <summary>
        /// Indica si cuando un usuario termina un curso se le envia mail o no.
        /// Solo para el rol empresa
        /// </summary>
        public virtual bool IsMailCursoTerminado
        {
            get
            {
                return isMailCursoTerminado;
            }
            set
            {
                isMailCursoTerminado = value;
            }
        }

        #endregion

        #region Contraseñas que se usan solomente para la vista de cambiar contraseña, no se mapean

        [StringLength(250, ErrorMessage = "La contraseña no puede superar los 250 caracteres")]
        [Display(Name = "Contraseña Nueva")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?!.*(.)\1\1)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)([a-zA-Z0-9_-]{6,})$", ErrorMessage = "La contraseña debe superar los 6 dígitos y debe incluir una maýuscula, una minúscula y un número")]
        public virtual string NewPassword
        {
            get
            {
                return newPassword;
            }

            set
            {
                newPassword = value;
            }
        }

        [StringLength(250, ErrorMessage = "La contraseña no puede superar los 250 caracteres")]
        [Display(Name = "Repita Contraseña")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?!.*(.)\1\1)(?=.*[a-z])(?=.*[A-Z])(?=.*\d)([a-zA-Z0-9_-]{6,})$", ErrorMessage = "La contraseña debe superar los 6 dígitos y debe incluir una maýuscula, una minúscula y un número")]
        public virtual string NewPasswordRepeat
        {
            get
            {
                return newPasswordRepeat;
            }

            set
            {
                newPasswordRepeat = value;
            }
        }

        [Display(Name = "Empresa")]
        /// <summary>
        /// Empresa
        /// </summary>
        public virtual Empresa Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                empresa = value;
            }
        }

        #endregion
    }
}

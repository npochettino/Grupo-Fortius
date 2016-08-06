using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public class Module : EntityBase
    {
        #region Members

        private string name;
        private string caption;
        private string action;
        private string icon;
        private string description;
        private int type;
        private bool active;
        private bool enabled;
        private int order;
        private Module parent;
        private IList<Module> children;
        #endregion

        #region Properties        

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(250, ErrorMessage = "El nombre no puede superar los 250 caracteres")]
        [Display(Name = "Nombre")]
        /// <summary>
        /// Nombre.
        /// </summary>
        public virtual string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        [Required(ErrorMessage = "El caption es requerido")]
        [StringLength(250, ErrorMessage = "El caption no puede superar los 250 caracteres")]
        [Display(Name = "Caption")]
        /// <summary>
        /// 
        /// </summary>
        public virtual string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
            }
        }

        [Required(ErrorMessage = "La acción es requerida")]
        [StringLength(250, ErrorMessage = "El nombre de la acción no puede superar los 250 caracteres")]
        [Display(Name = "Acción")]
        /// <summary>
        /// Accion.
        /// </summary>
        public virtual string Action
        {
            get
            {
                return action;
            }

            set
            {
                action = value;
            }
        }

        [StringLength(250, ErrorMessage = "El nombre del ícono no puede superar los 250 caracteres")]
        [Display(Name = "Ícono")]
        /// <summary>
        /// Icono.
        /// </summary>
        public virtual string Icon
        {
            get
            {
                return icon;
            }

            set
            {
                icon = value;
            }
        }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(250, ErrorMessage = "La descripción no puede superar los 250 caracteres")]
        [Display(Name = "Descripción")]
        /// <summary>
        /// Descripcion.
        /// </summary>
        public virtual string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        //[Required(ErrorMessage = "El tipo es requerido")]
        [Display(Name = "Tipo")]
        [Range(0, 3, ErrorMessage = "El orden debe estar entre 1 y 3")]
        /// <summary>
        /// Tipo.
        /// </summary>
        public virtual int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }        

        [Display(Name = "Habilitado")]
        /// <summary>
        /// Habilitado
        /// </summary>
        public virtual bool Enabled
        {
            get
            {
                return enabled;
            }

            set
            {
                enabled = value;
            }
        }

        [Required(ErrorMessage = "El orden es requerido")]
        [Display(Name = "Orden")]
        [Range(0, 1000, ErrorMessage = "El orden debe estar entre 0 y 1000")]
        /// <summary>
        ///  Orden
        /// </summary>
        public virtual int Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
            }
        }

        [Display(Name = "Módulo Padre")]
        /// <summary>
        /// Modulo padre.
        /// </summary>
        public virtual Module Parent
        {
            get
            {
                return parent;
            }

            set
            {
                parent = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [XmlIgnore]
        public virtual IList<Module> Children
        {
            get
            {
                return children;
            }
            set
            {
                children = value;
            }
        }
        #endregion

        #region Modules type

        enum TipoModulo
        {
            [EnumMember(Value = "Acción e Item de  Menú")]
            Modulo = 1,
            [EnumMember(Value = "Item de Menú sin Acción")]
            ItemDeMenú = 2,
            [EnumMember(Value = "Acción fuera del Menú")]
            Acción = 3,
        }

        #endregion
    }
    public static class ModulesType
    {
        /// <summary>
        /// Acciones de controlador que estan también en el menú, por ejemplo las acciones a grillas
        /// </summary>
        public const int MENU_ACTION = 1;

        /// <summary>
        /// Módulos que deben estar en el menú pero no tienen acciones asociadas
        /// </summary>
        public const int MENU_ITEM = 2;

        /// <summary>
        /// Acciones que no estan en el menú
        /// </summary>
        public const int ACTION = 3;
    }
}

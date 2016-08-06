using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCustomHelpers.Classes
{
    #region HelperClass Iconos

    /// <summary>
    /// Enumeración de Tipos de Iconos
    /// </summary>
    public class IconoTree
    {
        /// <summary>
        /// Icono Carpeta
        /// </summary>
        public const string folder = "folder";

        /// <summary>
        /// Icono Archivos
        /// </summary>
        public const string file = "file";
    }

    #endregion

    /// <summary>
    /// Representa una estructura de arbol
    /// </summary>
    [Serializable]
    public class TreeNode
    {
        #region Properties

        /// <summary>
        /// ID Nodo
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// Etiqueta
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool inode { get; set; }

        /// <summary>
        /// Esta abierto?
        /// </summary>
        public bool? open { get; set; }

        /// <summary>
        /// Icono
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// Rama
        /// </summary>
        public List<TreeNode> branch = new List<TreeNode>();

        /// <summary>
        /// Jerarquia
        /// </summary>
        public string jerarquia { get; set; }

        /// <summary>
        /// Nivel
        /// </summary>
        public int nivel { get; set; }

        /// <summary>
        /// Checkbox
        /// </summary>
        public bool checkbox { get; set; }

        /// <summary>
        /// RadioButton
        /// </summary>
        public bool radio { get; set; }

        /// <summary>
        /// Checkeado?
        /// </summary>
        public bool @checked { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Ctor
        /// </summary>
        public TreeNode() { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Crea un arbol
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="NombreNodo"></param>
        /// <param name="MostrarExpandido"></param>
        /// <param name="TieneHijos"></param>
        /// <param name="Checkbox"></param>
        public TreeNode(long ID, string NombreNodo, bool MostrarExpandido, bool TieneHijos, bool Checkbox)
        {
            this.id = ID;
            this.label = NombreNodo;
            this.open = MostrarExpandido;
            this.inode = TieneHijos;
            this.checkbox = Checkbox;
        }

        /// <summary>
        /// Crea un arbol
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="NombreNodo"></param>
        /// <param name="MostrarExpandido"></param>
        /// <param name="TieneHijos"></param>
        /// <param name="Checkbox"></param>
        /// <param name="radio"></param>
        /// <param name="@checked"></param>
        public TreeNode(long ID, string NombreNodo, bool MostrarExpandido, bool TieneHijos, bool Checkbox, bool radio, bool @checked)
        {
            this.id = ID;
            this.label = NombreNodo;
            this.open = MostrarExpandido;
            this.inode = TieneHijos;
            this.checkbox = Checkbox;
            this.radio = radio;
            this.@checked = @checked;
        }

        /// <summary>
        /// Crea un arbol
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="NombreNodo"></param>
        /// <param name="MostrarExpandido"></param>
        /// <param name="Icono"></param>
        /// <param name="TieneHijos"></param>
        public TreeNode(long ID, string NombreNodo, bool MostrarExpandido, IconoTree Icono, bool TieneHijos)
        {
            this.id = ID;
            this.label = NombreNodo;
            this.open = MostrarExpandido;
            this.icon = Icono.ToString();
            this.inode = TieneHijos;
        }
        #endregion
    }
}
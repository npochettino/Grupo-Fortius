using DALC.NHibernate;
using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logic.GrupoFournier;

namespace PresentacionGrupoFournier.Globales
{
    public static class VariablesAplicacion
    {
        #region Logic

        private static RolLogic rolLogic;

        /// <summary>
        /// Logic de roles
        /// </summary>
        static RolLogic RolLogic
        {
            get
            {
                if(rolLogic==null)
                {
                    rolLogic = new RolLogic();
                }
                return rolLogic;
            }
        }

        #endregion

        #region Miembros

        private static List<Rol> roles;

        #endregion

        #region Propiedades

        public static List<Rol> Roles
        {
            get
            {
                if(roles==null)
                {
                    roles = RolLogic.GetAllActivos();
                }
                return roles;
            }
            set
            {
                roles = value;
            }
        }

        #endregion

        
        public static void LoadOnInit()
        {
            roles = RolLogic.GetAllActivos(NHibernateManager.GetInstance().SessionInicioAplicacion);
        }
    }
}
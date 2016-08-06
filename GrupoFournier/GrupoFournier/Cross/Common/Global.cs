using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.Common
{
    /// <summary>
    /// Clase para enumeraciones/keys.
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// Keys para acceso a sesiones.
        /// </summary>
        public static class SessionsKeys
        {
            /// <summary>
            /// Key para acceder a la session de usuario.
            /// </summary>
            public const string USER_SESSION = "Usuario";
        }

        /// <summary>
        /// Keys para acceso a cookies
        /// </summary>
        public static class CookiesKey
        {           

        }

        /// <summary>
        /// Keys para acceso a TempData.
        /// </summary>

        /// <summary>
        /// Enumeración para los tipos de módulos
        /// </summary>
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

        /// <summary>
        /// Parametros de Ruteo de URL
        /// </summary>
        public static class RouteParam
        {
            /// <summary>
            /// Key de acceso - Route > Controlador
            /// </summary>
            public const string Controller = "controller";

            /// <summary>
            /// Key de acceso - Route > Acción
            /// </summary>
            public const string Action = "action";
        }

        /// <summary>
        /// Enumeración para los tipos de mails
        /// </summary>
        public enum MailsTypes : int
        {
            REGISTRO = 1,
            CAMBIO_CONTRASEÑA = 2,
            CURSO_FINALIZADO = 3
        }

        /// <summary>
        /// Enumeración para los roles
        /// </summary>
        public enum Roles : int
        {
            ADMINISTRADOR = 1,
            ADMINISTRADOR_SITIO = 2,
            EMPRESA = 3,
            ALTO = 4,
            BAJO = 5,
            MEDIO = 6
        }
    }
}

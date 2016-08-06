using Cross.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fwk.Session
{
    public static class SessionManager
    {
        #region Methods

        /// <summary>
        /// Metodo para obtener una session.
        /// </summary>
        /// <typeparam name="T">Tipo de la Entidad</typeparam>
        /// <param name="key">Session Key</param>
        /// <returns>T</returns>
        public static T Get<T>(string key)
        where T : class
        {
            object obj = HttpContext.Current.Session[key];

            if (obj == null)
            {
                return null;
            }
            return (T)obj;
        }

        /// <summary>
        /// Metodo para obtener valor de una session.
        /// </summary>
        /// <typeparam name="T">struct</typeparam>
        /// <param name="key">Session Key</param>
        /// <returns>T</returns>
        public static T GetValue<T>(string key)
        where T : struct
        {
            object obj = HttpContext.Current.Session[key];

            if (obj == null)
            {
                return default(T);
            }
            return (T)obj;
        }

        /// <summary>
        /// Metodo para darle valor a una session
        /// </summary>
        /// <param name="key">Session Key</param>
        /// <param name="value">Valor de la Session</param>
        public static void Set(string key, object value)
        {
            if (value == null)
            {
                HttpContext.Current.Session.Remove(key);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        /// <summary>
        /// Quita una Key de la session actual
        /// </summary>
        /// <param name="key">Session Key</param>
        public static void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }

        #endregion

        #region Inner Class

        /// <summary>
        /// Current User -> Usuario que corre la apliacación
        /// </summary>
        public class User
        {
            #region Members

            /// <summary>
            /// ID Usuario
            /// </summary>
            private const string PROP_ID = "EntityID";

            /// <summary>
            /// UserName
            /// </summary>
            private const string PROP_NAME = "Name";

            /// <summary>
            /// Nombre del Usuario
            /// </summary>
            private const string PROP_FULLNAME = "FullName";

            #endregion

            #region Properties

            /// <summary>
            /// SessionManager Accessor
            /// </summary>
            private static object CurrentUser
            {
                get
                {
                    if (Get<object>(Global.SessionsKeys.USER_SESSION) != null)
                        return HttpContext.Current.Session[Global.SessionsKeys.USER_SESSION];
                    else
                        return null;
                }
            }

            #endregion

            #region Private Methods

            /// <summary>
            /// Retorna el valor de la propiedad enviada como parametro
            /// </summary>
            /// <typeparam name="T">Tipo de Parametro</typeparam>
            /// <param name="propName">Nombre de la propiedad</param>
            /// <returns>T</returns>
            private static T GetPropertyValue<T>(string propName)
            {
                if (CurrentUser != null && CurrentUser.GetType().GetProperty(propName).GetValue(CurrentUser, null) != null)
                {
                    return (T)CurrentUser.GetType().GetProperty(propName).GetValue(CurrentUser, null);
                }
                else
                {
                    return default(T);
                }
            }

            #endregion

            #region User

            /// <summary>
            /// Usuario Logueado -> ID
            /// </summary>
            public static long UserID
            {
                get { return GetPropertyValue<long>(PROP_ID); }
            }

            /// <summary>
            /// Usuario Logueado -> Nombre de Usuario
            /// </summary>
            public static string UserName
            {
                get { return GetPropertyValue<string>(PROP_NAME); }
            }

            /// <summary>
            /// Usuario Logueado -> Nombre y Apellido
            /// </summary>
            public static string FullName
            {
                get { return GetPropertyValue<string>(PROP_FULLNAME); }
            }

            #endregion
        }

        #endregion
    }
}

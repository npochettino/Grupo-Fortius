using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Fwk.Session;
using NHibernate;
using NHibernate.Context;
//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NHibernate.Cfg;
using DALC.EntitiesMaps;

namespace DALC.NHibernate
{
    public class NHibernateManager
    {

        #region Members and Properties

        private ISession session = null;
        private ISessionFactory sessionFactory = null;

        private ISession sessionInicioAplicacion = null;
        public ISession SessionInicioAplicacion
        {
            get
            {
                if (sessionInicioAplicacion == null)
                {
                    sessionInicioAplicacion = GetInstance().SessionFactory.OpenSession();
                }
                return sessionInicioAplicacion;
            }
        }

        public void CerrarSessionInicioAplicacion()
        {
            if (sessionInicioAplicacion != null)
            {
                sessionInicioAplicacion.Dispose();
                sessionInicioAplicacion = null;
            }
        }

        /// <summary>
        /// NHibernate Session.
        /// </summary>
        public ISession Session
        {
            get
            {
                //if (HttpContext.Current.Session["NHibernateSession"] == null)
                //{
                //    HttpContext.Current.Session["NHibernateSession"] = SessionFactory.OpenSession();
                //}
                //return (ISession)HttpContext.Current.Session["NHibernateSession"];

                // -- Valido que este bindeada la session a la factory
                if (!CurrentSessionContext.HasBind(SessionFactory))
                {
                    // -- Si no esta bindeada la bindeo
                    CurrentSessionContext.Bind(SessionFactory.OpenSession());
                }
                // -- Devuelvo la sesion
                return SessionFactory.GetCurrentSession();
            }
        }

        /// <summary>
        /// Desbindea la sesion de la factory
        /// </summary>
        public void CloseSession()
        {
            // -- Si esta bindeada
            if (CurrentSessionContext.HasBind(SessionFactory))
            {
                // -- Desbindea
                CurrentSessionContext.Unbind(SessionFactory).Dispose();
            }
        }

        /// <summary>
        /// Borra la NHSession de la session de usuario
        /// </summary>
        public void CleanSession()
        {
            if (HttpContext.Current.Session["NHibernateSession"] != null)
            {
                ((ISession)HttpContext.Current.Session["NHibernateSession"]).Dispose();
                HttpContext.Current.Session["NHibernateSession"] = null;
            }
        }

        /// <summary>
        /// Retorno la sessionFactory, si no existe la creo
        /// </summary>
        public ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    sessionFactory = CreateSession();
                }
                return sessionFactory;
            }
        }

        /// <summary>
        /// Instancia de la clase.
        /// </summary>
        private static NHibernateManager Instance;

        /// <summary>
        /// Singleton que permite obtener siempre la misma instancia.
        /// </summary>
        /// <returns></returns>
        public static NHibernateManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new NHibernateManager();
            }
            return Instance;
        }

        #endregion

        // -- Ctor.
        private NHibernateManager()
        {

        }

        /// <summary>
        /// Crea una Session NHibernate.
        /// </summary>
        private ISessionFactory CreateSession()
        {
            // -- Crea una session factory
            ISessionFactory sf = Fluently
                .Configure().ExposeConfiguration(c => c.SetProperty(Environment.CurrentSessionContextClass, "web"))
                //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("Data Source=localhost;Initial Catalog=w1131306_GrupoFournier;Integrated Security=SSPI;"))
                //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("Data Source=localhost;Initial Catalog=w1131306_GrupoFortius;Integrated Security=SSPI;"))
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=fortius;integrated security=True;"))
                //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=w1402088_fortius;user=w1402088_sempait;password=Algoritmos2016"))//Hosting                    
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ModuleMap>())
                .BuildSessionFactory();

            return sf;
        }
        //data source=localhost\\sqlexpress;initial catalog=GrupoFournier;integrated security=True
        //Data Source=localhost;Initial Catalog=w1131306_GrupoFournier;Integrated Security=SSPI;
        /// <summary>
        /// Inicia una Session NHibernate.
        /// </summary>
        protected ISession InitSession()
        {
            return CreateSession().OpenSession();
        }

    }
}

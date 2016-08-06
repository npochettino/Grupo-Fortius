using DALC.NHibernate;
using PresentacionGrupoFournier.App_Start;
using PresentacionGrupoFournier.Controllers;
using PresentacionGrupoFournier.Fwk.UI;
using PresentacionGrupoFournier.Globales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PresentacionGrupoFournier
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            VariablesAplicacion.LoadOnInit();
            Menu.CreateRolesMenu();
            NHibernateManager.GetInstance().CerrarSessionInicioAplicacion();
            CustomModelBindersConfig.RegisterCustomModelBinders();
        }
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    RouteData routeData = new RouteData();
        //    routeData.Values.Add("controller", "ErrorController");
        //    routeData.Values.Add("action", "HandleTheError");
        //    routeData.Values.Add("error", exception);

        //    Response.Clear();
        //    Server.ClearError();

        //    IController errorController = new ErrorController();
        //    errorController.Execute(new RequestContext(
        //        new HttpContextWrapper(Context), routeData));
        //}
    }
}

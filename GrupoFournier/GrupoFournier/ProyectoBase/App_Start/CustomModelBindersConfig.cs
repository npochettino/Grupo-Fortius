using PresentacionGrupoFournier.Fwk.Helpers.ModelBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionGrupoFournier.App_Start
{
    public static class CustomModelBindersConfig
    {
        public static void RegisterCustomModelBinders()
        {
            ModelBinders.Binders.Add(typeof(DateTime), new CustomModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new NullableCustomDateBinder());
        }
    }
}
using Northwind.Entities;
using Northwind.MvcWebUI.Infrastructure;
using Northwind.MvcWebUI.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Bunlar hep extendable, kendin yeni anlamlar katıyorsun

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            //Eğer biri senden parametre olarak Cart nesnesi isterse, ona CartModelBinder'ı ver.
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}

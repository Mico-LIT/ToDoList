using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Modules;
using APP.Util;
using APP.BLL.Infrastructure;
using Ninject;
using Ninject.Web.Mvc;
using System.Web.Routing;

namespace APP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule TaskListModule = new TaskListModule();
            NinjectModule serviceModule = new ServiceModule(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\test\APP\App_Data\Database1.mdf;Integrated Security=True");
            var kernel = new StandardKernel(TaskListModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

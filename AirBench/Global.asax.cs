using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Http;
using System.Data.Entity;
using AirBench.Data;
using System.Security.Principal;
using AirBench.Security;
using System.Threading;
using AirBench.Repositories;
using AirBench.Models;

namespace AirBench
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new DatabaseInitializer());
        }
    }
}
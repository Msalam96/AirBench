using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
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
        private Context context;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new DatabaseInitializer());
        }

        protected void Application_PostAuthenticateRequest()
        {
            IPrincipal user = HttpContext.Current.User;

            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;

                CustomIdentity customIdentity = new CustomIdentity(ticket);

                string currentUserName = ticket.Name;

                var repository = new UserRepository(context);
                User loggedinUser = repository.GetLoggedInUser(currentUserName);

                CustomPrincipal customPrinicipal = new CustomPrincipal(customIdentity, loggedinUser);

                HttpContext.Current.User = customPrinicipal;
                Thread.CurrentPrincipal = customPrinicipal;
            }
        }
    }
}
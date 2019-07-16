using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (Context.User != null)
            {
                if (Context.User.Identity.IsAuthenticated == true)
                {
                    BusinessLayer.Roles rl = new BusinessLayer.Roles();
                    List<Common.Role> roles = rl.GetUserRoles(Context.User.Identity.Name).ToList();
                    string[] rolesarray = new string[roles.Count];
                    int count = 0;

                    foreach (Common.Role r in roles)
                    {
                        rolesarray[count] = r.RoleCode;
                        count++;
                    }

                    System.Security.Principal.GenericPrincipal gp = new System.Security.Principal.GenericPrincipal(Context.User.Identity, rolesarray);
                    Context.User = gp;
                }
            }
        }

    }
}

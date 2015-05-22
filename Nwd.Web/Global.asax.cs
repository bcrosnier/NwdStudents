using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Nwd.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            BundleConfig.RegisterBundles( BundleTable.Bundles );

        }

        protected void Application_Error( object sender, EventArgs e )
        {
            if( HttpContext.Current.IsDebuggingEnabled )
            {
                // Handle errors on ExecuteURL redirection
                Exception ex = HttpContext.Current.Server.GetLastError();
                if( ex != null )
                {
                    HttpContext.Current.Cache["LastError"] = ex;
                }
            }
        }
    }
}

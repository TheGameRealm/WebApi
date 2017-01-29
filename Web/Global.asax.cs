using Data.Entities;
using Data.Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.App_Start;

namespace Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Configure();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ActivateDatabaseForCodeFirstRebuild();

            logger.Info("********** Application Start **********");
        }

        protected void Application_End()
        {
            logger.Info("********** Application End **********");
        }

        /// <summary>
        /// Does not catch WebAPI Exceptions
        /// </summary>
        protected void Application_Error()
        {
            Exception ex = Server.GetLastError();

            // Handle HTTP errors
            if (ex.GetType() == typeof(HttpException))
            {
                if (ex.Message.Contains("NoCatch"))
                {
                    return;
                }

                Server.Transfer("/");
            }
            
            logger.Fatal(ex);

            Response.Write("<h2>Global Page Error</h2>\n");

            Server.ClearError();
        }

        /// <summary>
        /// Delete this method after the database is more fully implemented.
        /// </summary>
        private void ActivateDatabaseForCodeFirstRebuild()
        {
            using (var context = new RealmContext())
            {
                if (context.Maps.FirstOrDefault() != null)
                {
                    return;
                }
            }
        }
    }
}

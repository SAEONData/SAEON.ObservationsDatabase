﻿using SAEON.Observations.Core;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SAEON.Observations.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(HostingEnvironment.MapPath(@"~/App_Data/Logs/SAEON.Observations.WebAPI {Date}.txt"))
                .WriteTo.Seq("http://localhost:5341/")
                .CreateLogger();
            using (Logging.MethodCall(this.GetType()))
            {
                try
                {
                    BootStrapper.Initialize();
                    AreaRegistration.RegisterAllAreas();
                    GlobalConfiguration.Configure(WebApiConfig.Register);
                    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                    RouteConfig.RegisterRoutes(RouteTable.Routes);
                    BundleConfig.RegisterBundles(BundleTable.Bundles);

                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
    }
}

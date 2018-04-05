﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAPI_ZEST.AppCode;

namespace WebAPI_ZEST
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            GlobalConfiguration.Configuration.MessageHandlers.Add(new RequestHandler());
        }
    }
}

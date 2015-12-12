using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PU_Stub
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Make JSON default
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept", "text/html", StringComparison.InvariantCultureIgnoreCase, true, "application/json"));
        }
    }
}

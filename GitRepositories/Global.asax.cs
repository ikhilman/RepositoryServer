using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.SessionState;

namespace GitRepositories
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8040");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                //************************  Access-Control-Allow-Methods  ************************ 
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,OPTIONS");

                //************************  Access-Control-Allow-Headers ************************ 
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "range,x-range,x-requested-with,Origin,Content-Type,Accept,Cache-Control,brand,platform,lang,category,subCategory,authKey,appName,userUniqueId");

                //HttpContext.Current.Response.AddHeader("Access-Control-Expose-Headers", "Accept-Ranges");

                //************************  MAccess-Control-Max-Age ************************ 
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");

                HttpContext.Current.Response.End();//DO ONLY WHEN HttpMethod = "OPTIONS"
            }
            if (HttpContext.Current.Request.HttpMethod == "GET")//USE IN CMS CUSTOM PROPERTIES
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Expose-Headers", "Content-Range");
            }
        }

        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }
    }
}

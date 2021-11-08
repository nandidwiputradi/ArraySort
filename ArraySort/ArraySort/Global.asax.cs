using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Routing;

namespace ArraySort
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Map.Initialize(this.GetType(), "Default", "Index");
            Map.GetRoute(Request.Path);
            Map.GetData(Request.RequestType, Request.Params);
            object obj = Map.Redirect(Controller.ControllerName, Controller.ActionName);
            
            Response.Clear();
            Response.ContentType = Map.ContentType;
            Response.Write(obj);
            Response.End();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
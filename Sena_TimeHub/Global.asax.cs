using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Sena_TimeHub
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
             new ScriptResourceDefinition
             {
                 Path = "~/Scripts/jquery-3.7.1.min.js",
                 DebugPath = "~/Scripts/jquery-3.7.1.js",
                 CdnPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js",
                 CdnDebugPath = "https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.js"
             });
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["rol"] = null;
            Session["idUsuario"] = null;
            Session["autenticacion"] = "";
            Session["correoUsuario"] = "";
            Session["ruta"] = "";
            Session["correoEnviado"] = "false";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["rol"] = null ;
            Session["idUsuario"] = null;
            Session["autenticacion"] = "";
            Session["correoUsuario"] = "";
            Session["ruta"] = "";
            Session["correoEnviado"] = "false";

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
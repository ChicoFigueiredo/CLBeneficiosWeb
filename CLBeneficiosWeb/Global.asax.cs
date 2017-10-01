using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CLBeneficiosWeb.App_Start;
using CLBeneficiosWeb.Models;

namespace CLBeneficiosWeb
{
    public class MvcApplication : HttpApplication
    {


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application.Lock(); Application["UsersOnline"] = 0; Application.UnLock();
        }

        protected void Application_End()
        {
            
        }

        protected void Session_Start()
        {
            Application.Lock(); Application["UsersOnline"] = (int)Application["UsersOnline"] - 1; Application.UnLock();
            Session["Settings"] = new VariaveisSessao(HttpContext.Current.Request.Url.ToString());
        }

        protected void Session_End()
        {
            Application.Lock(); Application["UsersOnline"] = (int)Application["UsersOnline"] - 1; Application.UnLock();
        }


    }
}
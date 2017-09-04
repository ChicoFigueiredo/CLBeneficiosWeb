using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CLBeneficiosWeb.App_Start;

namespace CLBeneficiosWeb
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
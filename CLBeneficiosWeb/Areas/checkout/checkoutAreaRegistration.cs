using System.Web.Mvc;

namespace CLBeneficiosWeb.Areas.checkout
{
    public class checkoutAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "checkout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "checkout_default",
                "checkout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
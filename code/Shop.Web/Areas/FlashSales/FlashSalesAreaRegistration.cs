using System.Web.Mvc;

namespace Shop.Web.Areas.FlashSales
{
    public class FlashSalesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FlashSales";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "FlashSales_default",
                "FlashSales/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

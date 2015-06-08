using System.Web.Mvc;

namespace Shop.Web.Areas.SiteConfig
{
    public class SiteConfigAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SiteConfig";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SiteConfig_default",
                "SiteConfig/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

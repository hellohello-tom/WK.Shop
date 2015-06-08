using System.Web.Mvc;

namespace Shop.Web.Areas.Phone
{
    public class PhoneAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Phone";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Phone_default",
                "Phone/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

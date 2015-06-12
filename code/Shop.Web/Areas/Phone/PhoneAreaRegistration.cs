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

        public override void RegisterArea( AreaRegistrationContext context )
        {
            var yaodianArea = new[] { "Shop.Web.Areas.Phone.Controllers" };
            context.MapRoute(
                "Phone_yaodian",
                "yaodian",
                new { Controller = "Commodity", action = "Index" },
                yaodianArea
            );

            context.MapRoute(
                "Phone_yaoList",
                "yaodian/list/{tagId}",
                new { Controller = "Commodity", action = "CommodityList", tagId = 0 },
                yaodianArea
            );

            context.MapRoute(
                "Phone_yaoDeatil",
                "yaodian/detail/{Id}",
                new { Controller = "Commodity", action = "CommodityDeatil", Id = UrlParameter.Optional },
                yaodianArea
            );

            context.MapRoute(
                "Phone_yaoSearch",
                "yaodian/search",
                new { Controller = "Search", action = "Index"},
                yaodianArea
            );

            context.MapRoute(
                "Phone_default",
                "Phone/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                yaodianArea
            );
        }
    }
}

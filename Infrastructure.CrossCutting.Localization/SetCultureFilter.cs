using System;
using System.Web;
using System.Web.Mvc;
using Infrastructure.CrossCutting.Localization;

namespace TranslatedWeb.Filters
{
    public class SetCultureFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = (string) filterContext.RouteData.Values["lang"];
            CultureHelpers.SetCulture(culture);
            base.OnActionExecuting(filterContext);
        }
    }
}
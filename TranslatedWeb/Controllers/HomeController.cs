using System.Web.Mvc;
using Infrastructure.CrossCutting.Localization;
using Resources;
using TranslatedWeb.Filters;

namespace TranslatedWeb.Controllers
{
    [SetCultureFilter]
    public class HomeController : Controller
    {
        private string _currentCulture = "en";
        public ActionResult Index()
        {
            ViewBag.Message = Global.HOMEMESSAGE;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = Global.ABOUTVIEW;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = Global.CONTACTVIEW;

            return View();
        }

        public ActionResult ChangeLanguage(int id)
        {
            switch (id)
            {
                case 1:
#if DEBUG
                    CultureHelpers.SetCulture("es"); // Duplicated code due to be used in tests
#endif
                    _currentCulture = "es";
                    break;
                case 2:
#if DEBUG
                    CultureHelpers.SetCulture("zh"); // Duplicated code due to be used in tests
#endif
                    _currentCulture = "zh";
                    break;
                default:
#if DEBUG
                    CultureHelpers.SetCulture("en");
#endif
                    _currentCulture = "en";
                    break;
            }

            return RedirectToAction("Index", new {lang = _currentCulture});
        }

        public ViewResult TestLanguage()
        {
            ViewBag.Title = Global.TESTTITLE;
            return View();
        }


    }

}

using System.Web.Mvc;
using UnibenWeb.Application.Interface;

namespace UnibenWeb.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBancoAppService _bancoAppService;

        public HomeController(IBancoAppService bancoAppService)
        {
            _bancoAppService = bancoAppService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult SignOut()
        {
            ViewBag.Message = "Sair";
            return View();
        }

        public ActionResult BoletoPreview()
        {
            //ViewBag.Message = "Your contact page.";
            @ViewBag.Page = _bancoAppService.BoletoImprimir();
            return View();
        }

    }
}
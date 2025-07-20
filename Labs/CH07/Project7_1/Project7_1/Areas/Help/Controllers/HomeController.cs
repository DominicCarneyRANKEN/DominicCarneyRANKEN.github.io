using Microsoft.AspNetCore.Mvc;

namespace Project7_1.Areas.Help.Controllers
{
    [Area("Help")]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}

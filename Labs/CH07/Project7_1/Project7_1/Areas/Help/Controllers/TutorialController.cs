using Microsoft.AspNetCore.Mvc;

namespace Project7_1.Areas.Help.Controllers
{
    [Area("Help")]
    public class TutorialController : Controller
    {
        public IActionResult Index(int id)
        {
            if (id == 1)
                return View("Page1");
            else if (id == 2)
                return View("Page2");
            else
                return View("Page3");
        }
    }
}


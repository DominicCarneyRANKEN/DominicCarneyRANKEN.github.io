using Ch_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ch_02.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new Discount();
            return View(model);
        }


        [HttpPost]
        public IActionResult Index(Discount model)
        {
     
            if (!ModelState.IsValid)
            {
  
                return View(model);
            }

        
            return View(model);
        }
    }
}

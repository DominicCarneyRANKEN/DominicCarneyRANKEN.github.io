using System.Diagnostics;
using Distance.Models;
using Microsoft.AspNetCore.Mvc;

namespace Distance.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Distances());
        }

        [HttpPost]
        public IActionResult  Index(Distances model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
    }
}

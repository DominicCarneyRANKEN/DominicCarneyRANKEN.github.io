using Microsoft.AspNetCore.Mvc;
using Project_2_2.Models;

namespace Project_2_2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Calculator(); 
            return View(model); 
        }


        [HttpPost]
        public IActionResult Index(Calculator model)
        {
      
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

           
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Project1.Models;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        //Kestrel is the web server
        //.NET Core is the application server
        //SQL Server is the DB server

        //Action method
        //Reutrn data type is IActionResult
        [HttpGet]
        public IActionResult Index()
        {
            //ViewBag is a dynamic property that's inherited from Controller
            //You can add any property to it
            //ViewBag is then used in the view
            ViewBag.FV = 0;
            return View();
        }

        [HttpPost]
        public IActionResult Index(FutureValueModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FV = model.CalculateFutureValue();
                
            }
            else
            {
                ViewBag.FV = 0;
            }
            return View(model); //binds the model to the view


        }
    }
}

using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers
{
    [Route("Retail/{controller}/{action}/{id?}")]
    public class Product : Controller
    {
        //public IActionResult List(string id, string num, string sortby="Price")
        //{
        //    return Content($"Product Controller, List Action, id: {id}, num: {num}, sortby: {sortby}");
        //}

        [Route("Products/{id?}")]
        public IActionResult List(string id = "all")
        {
            return Content($"Product controller, list action, category {id}");
        }



        [Route("product/{id}")]
        public IActionResult Detail(int id)
        {
            return Content($"Product Controller, Detail Action, id: {id}");
        }

        [NonAction]
        public void DoSomething()
        {
            
        }


     


    }
}

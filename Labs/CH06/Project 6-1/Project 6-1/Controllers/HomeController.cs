using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_6_1.Models;

namespace Project_6_1.Controllers
{
    public class HomeController : Controller
    {
        private QuestionContext Context { get; }

        public HomeController(QuestionContext context)
        {
            Context = context;
        }

        [Route("/")]
        [Route("topic/{topic}")]
        [Route("category/{category}")]
        [Route("topic/{topic}/category/{category}")]

        [HttpGet]
        public async Task<IActionResult> Index(string category = null, string topic = null)
        {
            var faqs = Context.Question.Include(q => q.Category).Include(q => q.Topic).AsQueryable();

          
            if (!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(q => q.Category.CategoryType.ToLower() == category.ToLower());
            }

           
            if (!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(q => q.Topic.TheTopic.ToLower() == topic.ToLower());
            }

            return View(await faqs.ToListAsync());
        }
    }
}

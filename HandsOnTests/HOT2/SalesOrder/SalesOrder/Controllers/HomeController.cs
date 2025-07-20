using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesOrder.Models;

namespace SalesOrder.Controllers
{
    public class HomeController : Controller
    {
        private SalesContext Context;

        public HomeController(SalesContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            var products = Context.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = Context.Products.Include(p => p.Category).ToList();
            return View(products); 
        }


        [HttpGet]
        public IActionResult Add()
        {
         
            var categories = Context.Categories
                .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName })
                .ToList();

            ViewBag.Categories = categories;
            return View("AddEdit", new Product()); 
        }


        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = Context.Products.Find(id);
            if (product == null)
            {
                return NotFound(); 
            }

          
            ViewBag.Categories = Context.Categories
                .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName })
                .ToList();

            return View("AddEdit", product); 
        }

        [HttpPost]
        public async Task<IActionResult> Save([Bind("ProductID, ProductName, Slug, ProductImage, ProductDescShort, ProductDescLong, ProductPrice, ProductQty, CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                
                if (product.ProductID != 0)
                {
                    if (string.IsNullOrEmpty(product.ProductImage))
                    {

                        var existingProduct = Context.Products.AsNoTracking().FirstOrDefault(p => p.ProductID == product.ProductID);
                        product.ProductImage = existingProduct?.ProductImage;
                    }
                }
                else
                {
                  
                    if (string.IsNullOrEmpty(product.ProductImage))
                    {
                        product.ProductImage = "/images/default-image.jpg"; 
                    }
                }

              
                product.Slug = product.ProductName.ToLower().Replace(" ", "-");

                if (product.ProductID == 0)
                {
                   
                    Context.Products.Add(product);
                }
                else
                {
                    
                    Context.Products.Update(product);
                }

                await Context.SaveChangesAsync(); 
                return RedirectToAction("List");
            }

            
            ViewBag.Categories = Context.Categories
                .Select(c => new SelectListItem { Value = c.CategoryID.ToString(), Text = c.CategoryName })
                .ToList();

            return View("AddEdit", product); 
        }

       
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = Context.Products.Find(id);
            if (product == null)
            {
                return NotFound(); 
            }

            return View(product); 
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var product = Context.Products.Find(id);
            if (product != null)
            {
                Context.Products.Remove(product);
                Context.SaveChanges(); 
            }

            return RedirectToAction("List"); 
        }
    }
}


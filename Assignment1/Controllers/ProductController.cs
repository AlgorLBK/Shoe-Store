using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext context;
        private RegisterContext registerContext;
        private readonly IWebHostEnvironment env;

        public ProductController(ShopContext ctx,  IWebHostEnvironment env, RegisterContext registerContext)
        {
            this.env = env;
            context = ctx;
            this.registerContext = registerContext;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Buy", "Product");
        }

        [Route("[controller]s/{id?}")]
        public IActionResult Buy(string id)
        {
            
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();
            
            List<Product> products;
            var images = context.Products.OrderBy(c => c.Code).ToList();
            ViewBag.Image = images + ".jpg";

            id ??= "All";
            if (id == "All")
            {
                products = context.Products
                    .OrderBy(p => p.ProductID).ToList();
            }
            else
            {
                products = context.Products
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.ProductID).ToList();
            }


            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;
            return View(products);
        }
        
        public IActionResult Sell()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(int category, string name, string description, DateTime datestart, DateTime dateend, string condition, decimal price, string user ,IFormFile code)
        {
            if (ModelState.IsValid)
            {
                
                var cat = context.Categories.SingleOrDefault(c => c.CategoryID == category);
                var path = Path.Combine(env.WebRootPath, "img");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var filename = Guid.NewGuid().ToString() + Path.GetExtension(code.FileName);
                var filepath = Path.Combine(path, filename);
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await code.CopyToAsync(stream);
                }
                Product vendre = new()
                {
                    CategoryID = category,
                    Description = description,
                    StartBid = datestart.ToString("d"),
                    EndBid = dateend.ToString("d"),
                    Condition = condition,
                    Code = filename.Replace(".jpg", ""),
                    Name = name,
                    Price = price,
                    UserAuhtor = user

                };
                context.Products.Add(vendre);
                
            }
            context.SaveChanges();
            return RedirectToAction("Buy", "Product");

        }
        
        public IActionResult Details(int id)
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            Product product = context.Products.Find(id);

            string imageFilename = product.Code + ".jpg";
            ViewBag.Categories = categories;
            ViewBag.ImageFilename = imageFilename;

            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int code)
        {
            var product = context.Products.Find(code);
            return View(product);
            
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Buy", "Product");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
            
            return View();
        }

        public IActionResult Auction()
        {
            return View();
        }
    }
}

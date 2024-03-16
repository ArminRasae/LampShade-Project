using linqTesty.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace linqTesty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Product A", Category = "Category 1", Price = 100
                },
                new Product { Id = 2, Name = "Product B", Category = "Category 2", Price = 150
                },
                new Product { Id = 3, Name = "Product C", Category = "Category 1", Price = 120
                },
                new Product { Id = 4, Name = "Product D", Category = "Category 3", Price = 200
                },
                new Product { Id = 5, Name = "Product E", Category = "Category 2", Price = 80 }
            };


            //all products in Category 1
            //var res1 = products.Where(x => x.Category == "Category 1").ToList();
            //var res2 = products.GroupBy(x => x.Category).ToList();
            //ViewData["GroupedProducts"] = res2;
            //var res3 = products.Where(x => x.Price )

            var product = products.ToList();
            var groupedProducts = products.GroupBy(x => x.Category).ToList();
            var productNames = products.Select(x => x.Name).ToList();
            ViewData["GroupedProducts"] = groupedProducts;
            ViewData["ProductNames"] = productNames;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
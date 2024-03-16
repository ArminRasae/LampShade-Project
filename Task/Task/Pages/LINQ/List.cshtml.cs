using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskManagement.Application.Contracts;


namespace Task.Pages.LINQ
{
    public class ListModel : PageModel
    {
        private readonly IProductApplication _productApplication;

        public ListModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        public double AveragePrice { get; private set; }
        public List<ProductViewModel> Category1Products { get; private set; }
        public IEnumerable<IGrouping<string, ProductViewModel>> GroupedProducts { get; private set; }
        public ProductViewModel HighestPricedProduct { get; private set; }
        public double TotalPrice { get; private set; }

        public IActionResult OnGet()
        {
            
            AveragePrice = _productApplication.AveragePrice();
            Category1Products = _productApplication.Category1Products();
            GroupedProducts = _productApplication.GroupedProducts();
            HighestPricedProduct = _productApplication.HighestPriceProduct();
            TotalPrice = _productApplication.TotalPrice();

            return Page();
        }
    }
}
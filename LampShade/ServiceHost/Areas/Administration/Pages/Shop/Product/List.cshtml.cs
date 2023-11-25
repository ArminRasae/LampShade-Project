using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Application.Contracts.ProductCategoryApp;


namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class ListModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
      
        public List<ProductViewModel> ProductView { get; set; }

        public ProductSearchModel SearchModel;

        public SelectList CategoryItem;


        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public ListModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(ProductSearchModel searchModel)
        {
            ProductView = _productApplication.Search(searchModel);

            CategoryItem = new SelectList(_productCategoryApplication.GetCategoryItem(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductCommand();
            command.Categories = _productCategoryApplication.GetCategoryItem();

            return Partial("Create", command);
        }

        public JsonResult OnPostCreate(CreateProductCommand command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetailsBy(id);
            product.Categories = _productCategoryApplication.GetCategoryItem();
            return Partial("Edit", product);
        }

        public IActionResult OnPostEdit(EditProductCommand command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetNotInStock(long id)
        {
            var result = _productApplication.NotInStock(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./List");
            }

            Message = result.Message;
            return RedirectToPage("./List");

        }

        public IActionResult OnGetIsInStock(long id)
        {
            

            var result = _productApplication.IsStock(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./List");
            }

            Message = result.Message;
            return RedirectToPage("./List");

        }

    }
}

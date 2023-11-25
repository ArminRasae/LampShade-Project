using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategoryApp;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        
        public List<ProductCategoryViewModel> ProductCategoryView { get; set; }

        public ProductCategorySearchModel SearchModel;
       



        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }


        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategoryView = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("Create");
        }

        public JsonResult OnPostCreate(CreateProductCategoryCommand command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id) 
        {
            var productCategory = _productCategoryApplication.GetDetailsBy(id);
            return Partial("Edit",productCategory);
        }

        public IActionResult OnPostEdit(EditProductCategoryCommand command)
        {
            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetIsRemove(long id)
        {
            var result = _productCategoryApplication.IsRemove(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./List");
            }

            Message = result.Message;
            return RedirectToPage("./List");

        }

        public IActionResult OnGetIsRestore(long id)
        {


            var result = _productCategoryApplication.IsRestore(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./List");
            }

            Message = result.Message;
            return RedirectToPage("./List");

        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductApp;
using ShopManagement.Application.Contracts.ProductPictureApp;


namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class ListModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
      
        public List<ProductPictureViewModel> ProductPictureView { get; set; }

        public ProductPictureSearchModel SearchModel;

        public SelectList ProductItem; 


        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public ListModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
            _productPictureApplication = productPictureApplication;
        }


     
        public void OnGet(ProductPictureSearchModel searchModel)
        {
            ProductPictureView = _productPictureApplication.Search(searchModel);

            ProductItem = new SelectList(_productApplication.GetProductsItem(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture();

            command.Products = _productApplication.GetProductsItem();

            return Partial("Create", command);
        }

        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            productPicture.Products= _productApplication.GetProductsItem();
            return Partial("Edit", productPicture);
        }

        public IActionResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureApplication.Remove(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./List");
            }

            Message = result.Message;
            return RedirectToPage("./List");

        }

        public IActionResult OnGetRestore(long id)
        {
            

            var result = _productPictureApplication.Restore(id);
            if (result.IsSucceeded)
            {
                return RedirectToPage("./List");
            }

            Message = result.Message;
            return RedirectToPage("./List");

        }

    }
}

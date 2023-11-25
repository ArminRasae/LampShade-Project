using DiscountManagement.Application.Contracts.CustomerDiscountApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductApp;


namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class ListModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
      
        public List<CustomerDiscountViewModel> CustomerDiscountsList { get; set; }

        public CustomerDiscountSearchModel SearchModel;

        public SelectList ProductsItem;
        



        private readonly IProductApplication _productApplication;
        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        public ListModel(IProductApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _customerDiscountApplication = customerDiscountApplication;
        }


        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            CustomerDiscountsList = _customerDiscountApplication.Search(searchModel);

            ProductsItem = new SelectList(_productApplication.GetProductsItem(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineCustomerDiscountCommand()
            {
                ProductsItem = _productApplication.GetProductsItem(),
            };
            
                
            return Partial("Create", command);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscountCommand command)
        {
            var result = _customerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _customerDiscountApplication.GetDetails(id);
            product.ProductsItem = _productApplication.GetProductsItem();
            return Partial("Edit", product);
        }

        public IActionResult OnPostEdit(EditCustomerDiscountCommand command)
        {
            var result = _customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

    
        

    }
}

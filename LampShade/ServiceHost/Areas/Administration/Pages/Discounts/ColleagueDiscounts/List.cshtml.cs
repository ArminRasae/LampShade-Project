using DiscountManagement.Application.Contracts.ColleagueDiscountApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductApp;


namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    public class ListModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
      
        public List<ColleagueDiscountViewModel> ColleagueDiscountsList { get; set; }

        public ColleagueDiscountSearchModel SearchModel;

        public SelectList ProductsItem;
        



        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _ColleagueDiscountApplication;
        public ListModel(IProductApplication productApplication, IColleagueDiscountApplication ColleagueDiscountApplication)
        {
            _productApplication = productApplication;
            _ColleagueDiscountApplication = ColleagueDiscountApplication;
        }


        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            ColleagueDiscountsList = _ColleagueDiscountApplication.Search(searchModel);

            ProductsItem = new SelectList(_productApplication.GetProductsItem(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscountCommand()
            {
                ProductsItem = _productApplication.GetProductsItem(),
            };
            
                
            return Partial("Create", command);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscountCommand command)
        {
            var result = _ColleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _ColleagueDiscountApplication.GetDetailsBy(id);
            product.ProductsItem = _productApplication.GetProductsItem();
            return Partial("Edit", product);
        }

        public IActionResult OnPostEdit(EditColleagueDiscountCommand command)
        {
            var result = _ColleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var colleagueDiscount = _ColleagueDiscountApplication.Remove(id);
            return RedirectToPage("./List");
        }
         
        public IActionResult OnGetRestore(long id)
        {
            
            var colleagueDiscount = _ColleagueDiscountApplication.Restore(id);
            return RedirectToPage("./List");
        }

    
        

    }
}

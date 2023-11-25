using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Slide;


namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class ListModel : PageModel
    {
        private readonly ISlideApplication _slideApplication;
        public ListModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

       
        [TempData] public string Message { get; set; }
        public List<SlideViewModelCommand> Slides { get; set; }
        public void OnGet()
        {
            Slides = _slideApplication.GetList();

        }

        public IActionResult OnGetCreate()
        {
;            return Partial("./Create",new CreateSlideCommand());
        }

        public JsonResult OnPostCreate(CreateSlideCommand command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            return Partial("./Edit", _slideApplication.GetDetailsBy(id));
        }

        public IActionResult OnPostEdit(EditSlideCommand command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _slideApplication.Remove(id);
            if (result.IsSucceeded)
                return RedirectToPage("./List");
            Message = result.Message;
            return RedirectToPage("./List");

        }

        public IActionResult OnGetRestore(long id)
        {

            var result = _slideApplication.Restore(id);
            if (result.IsSucceeded)
                return RedirectToPage("./List");
            Message = result.Message;
            return RedirectToPage("./List");

        }
    }
}

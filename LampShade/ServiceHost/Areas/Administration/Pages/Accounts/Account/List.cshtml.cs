using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class ListModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;

        public ListModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public List<AccountViewModel> AccountView;
        public AccountSearchModel SearchModel  { get; set; }
        public SelectList RolesItem { get; set; }
        public void OnGet(AccountSearchModel searchModel)
        {
           AccountView = _accountApplication.Search(searchModel);
        }

        public ActionResult OnGetCreate()
        {
            var command = new CreateAccountCommand()
            {

            };
            return Partial("Create",command);
        }
        public JsonResult OnPostCreate(CreateAccountCommand command)
        {
            var account = _accountApplication.Create(command);
            return new JsonResult(account);
        }

        public ActionResult OnGetEdit(long id)
        {
            var account = _accountApplication.GetDetailsBy(id);
            return Partial("Edit",account);
        }

        public JsonResult OnPostEdit(EditAccountCommand command)
        {
           var result = _accountApplication.Edit(command);
           return new JsonResult(result);
        }


    }
}

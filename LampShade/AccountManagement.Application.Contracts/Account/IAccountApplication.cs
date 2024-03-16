using _0_Framework.Application;

namespace AccountManagement.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccountCommand command);
        EditAccountCommand GetDetailsBy(long id);    
        OperationResult Edit(EditAccountCommand command);
        OperationResult ChangePassword(ChangePassword command);
        List<AccountViewModel> Search(AccountSearchModel  searchModel);
    }
}

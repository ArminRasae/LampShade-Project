using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepositoryBase<long,Account>
    {
        EditAccountCommand GetDetailsBy(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
    }


}

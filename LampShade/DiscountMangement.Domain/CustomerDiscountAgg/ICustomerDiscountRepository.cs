using _0_Framework.Domain;
using DiscountManagement.Application.Contracts.CustomerDiscountApp;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository : IRepositoryBase<long,CustomerDiscount>
    {
        EditCustomerDiscountCommand GetDetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);

    }
}

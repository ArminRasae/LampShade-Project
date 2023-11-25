using _0_Framework.Application;

namespace DiscountManagement.Application.Contracts.CustomerDiscountApp
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Define(DefineCustomerDiscountCommand command);
        EditCustomerDiscountCommand GetDetails(long id);
        OperationResult Edit(EditCustomerDiscountCommand command);

        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);


    }
}

using _0_Framework.Application;

namespace DiscountManagement.Application.Contracts.ColleagueDiscountApp
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscountCommand command);
        OperationResult Edit(EditColleagueDiscountCommand command);
        EditColleagueDiscountCommand GetDetailsBy(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
        OperationResult Remove(long id);
        OperationResult Restore(long id);


    }
}

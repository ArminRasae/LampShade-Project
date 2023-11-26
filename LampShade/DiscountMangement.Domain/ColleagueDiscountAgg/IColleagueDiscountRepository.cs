
using _0_Framework.Domain;
using DiscountManagement.Application.Contracts.ColleagueDiscountApp;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository : IRepositoryBase<long,ColleagueDiscount>
    {
        EditColleagueDiscountCommand GetDetailsBy(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}

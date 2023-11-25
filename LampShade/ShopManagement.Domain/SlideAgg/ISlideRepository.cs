

using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Slide;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepositoryBase<long,Slide> 
    {
        EditSlideCommand GetDetailsBy(long id);
        List<SlideViewModelCommand> GetList();

    }
}

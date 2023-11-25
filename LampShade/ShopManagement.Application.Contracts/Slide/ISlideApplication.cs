

using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlideCommand command);
        OperationResult Edit(EditSlideCommand command);
        EditSlideCommand GetDetailsBy(long id);
        OperationResult Restore(long  id);
        OperationResult Remove(long id);
        List<SlideViewModelCommand> GetList();

    }
}

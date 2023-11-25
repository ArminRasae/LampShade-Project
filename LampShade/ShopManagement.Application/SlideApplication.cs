using _0_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public OperationResult Create(CreateSlideCommand command)
        {
            var operation = new OperationResult();
            var slide = new Slide(command.Link,command.Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.PictureTitle,command.Text,command.BtnText);
            _slideRepository.Create(slide);
            _slideRepository.Save();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditSlideCommand command)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(command.Id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            slide.Edit(command.Link, command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.PictureTitle, command.Text, command.BtnText);

            _slideRepository.Save();
            return operation.Succeeded();


        }

        public List<SlideViewModelCommand> GetList()
        {
            return _slideRepository.GetList();
        }

        public EditSlideCommand GetDetailsBy(long id)
        {
            return _slideRepository.GetDetailsBy(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            slide.Remove();
            _slideRepository.Save();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(id);
            slide.Restore();
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            _slideRepository.Save();
            return operation.Succeeded();
        }
    }
}

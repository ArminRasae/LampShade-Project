using _0_Framework.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscountApp;
using DiscountManagement.Domain.ColleagueDiscountAgg;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            _colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Define(DefineColleagueDiscountCommand command)
        {
            var operation = new OperationResult();
            if (_colleagueDiscountRepository.Exists(x =>
                    x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
           _colleagueDiscountRepository.Create(colleagueDiscount);
           _colleagueDiscountRepository.Save();
           return operation.Succeeded();
        }

        public OperationResult Edit(EditColleagueDiscountCommand command)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.GetBy(command.Id);
            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if(_colleagueDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            colleagueDiscount.Edit(command.ProductId, command.DiscountRate);
            _colleagueDiscountRepository.Save();
            return operation.Succeeded();
        }

        public EditColleagueDiscountCommand GetDetailsBy(long id)
        {
            return _colleagueDiscountRepository.GetDetailsBy(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.GetBy(id);
            if(colleagueDiscount == null )
                return operation.Failed(ApplicationMessages.RecordNotFound);

            colleagueDiscount.Remove();
            _colleagueDiscountRepository.Save();
            return operation.Succeeded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.GetBy(id);
            if (colleagueDiscount == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            colleagueDiscount.Restore();
            _colleagueDiscountRepository.Save();
            return operation.Succeeded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
           return _colleagueDiscountRepository.Search(searchModel);
        }
    }
}

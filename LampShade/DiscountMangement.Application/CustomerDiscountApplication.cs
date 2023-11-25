﻿using System.Xml.Linq;
using _0_Framework.Application;
using DiscountManagement.Application.Contracts.CustomerDiscountApp;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscountCommand command)

        {
            var operation = new OperationResult();
            if (_customerDiscountRepository.Exists(x =>
                    x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var customerDiscount = new CustomerDiscount(command.ProductId, command.DiscountRate,
                command.StartDate.ToGeorgianDateTime(),
                command.EndDate.ToGeorgianDateTime(),command.DiscountReason);

            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.Save();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditCustomerDiscountCommand command)
        {
            var operation = new OperationResult();

            var customerDiscount = _customerDiscountRepository.GetBy(command.Id);
            if (customerDiscount == null)
                operation.Failed(ApplicationMessages.RecordNotFound);

            if (_customerDiscountRepository.Exists(x =>
                    x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id == command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            customerDiscount!.Edit(command.ProductId, command.DiscountRate, command.StartDate.ToGeorgianDateTime(),
                command.EndDate.ToGeorgianDateTime(), command.DiscountReason);
            _customerDiscountRepository.Save();
            return operation.Succeeded();
        }

        public EditCustomerDiscountCommand GetDetails(long id)
        {
           return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}

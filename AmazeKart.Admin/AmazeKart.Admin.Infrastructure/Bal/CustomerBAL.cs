using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class CustomerBAL : ICustomerBAL
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerBAL(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }
        public ResultMessage Create(ViewModel.Customer entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Customer customer = new ObjectModel.Customer();
            _mapper.Map<ViewModel.Customer, ObjectModel.Customer>(entity, customer);
            return _customerService.Create(customer);
        }

        public ResultMessage Delete(int customerId)
        {
            return _customerService.Delete(customerId);
        }

        public IQueryable<ViewModel.Customer> GetAll()
        {
            var customers = _customerService.GetAll().ToList();
            List<ViewModel.Customer> customerList = new();
            customerList = _mapper.Map<List<ObjectModel.Customer>, List<ViewModel.Customer>>(customers);
            return customerList.AsQueryable();
        }

        public ViewModel.Customer GetById(int categoryId)
        {
            ObjectModel.Customer customer = _customerService.GetById(categoryId);
            ViewModel.Customer customerViewModel = _mapper.Map<ObjectModel.Customer, ViewModel.Customer>(customer);
            return customerViewModel;
        }

        public ResultMessage Update(ViewModel.Customer entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Customer customer = new ObjectModel.Customer();
            _mapper.Map<ViewModel.Customer, ObjectModel.Customer>(entity, customer);
            return _customerService.Update(customer);
        }
    }
}

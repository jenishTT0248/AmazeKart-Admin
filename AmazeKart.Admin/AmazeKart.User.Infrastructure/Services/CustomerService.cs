using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) 
        { 
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        public ResultMessage Create(Customer customer)
        {
            if (customer == null) return ResultMessage.RecordNotFound;
            bool isCustomerExists = _customerRepository.Any(y => y.Email == customer.Email && y.Active);
            if (isCustomerExists) return ResultMessage.RecordExists;

            _customerRepository.Create(customer);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int customerId)
        {
            Customer dbCustomer = _customerRepository.FindOne(x => x.Id == customerId && x.Active);
            if (dbCustomer == null) return ResultMessage.RecordNotFound;

            _customerRepository.Delete(dbCustomer);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public IQueryable<Customer> GetAll()
        {
           return _customerRepository.Find(x => x.Active);
        }

        public Customer GetById(int customerId)
        {
            return _customerRepository.FindOne(x => x.Id == customerId && x.Active);
        }

        public ResultMessage Update(Customer customer)
        {
            if (customer == null) return ResultMessage.RecordNotFound;

            if (_customerRepository.Any(x => x.Id != customer.Id && x.Email == customer.Email && x.Active))
            {
                return ResultMessage.RecordExists;
            }

            Customer dbCustomer = _customerRepository.FindOne(x => x.Id == customer.Id && x.Active);
            if (dbCustomer == null) return ResultMessage.RecordNotFound;

            _customerRepository.SetValues(dbCustomer, customer);
            _customerRepository.Update(dbCustomer);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }
    }
}
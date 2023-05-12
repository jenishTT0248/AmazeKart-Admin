using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
{
    public interface ICustomerService
    {
        ResultMessage Create(Customer customer);
        ResultMessage Update(Customer customer);
        ResultMessage Delete(int customerId);
        Customer GetById(int customerId);
        IQueryable<Customer> GetAll();
    }
}

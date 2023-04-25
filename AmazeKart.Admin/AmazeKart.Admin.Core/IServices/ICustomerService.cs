using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
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

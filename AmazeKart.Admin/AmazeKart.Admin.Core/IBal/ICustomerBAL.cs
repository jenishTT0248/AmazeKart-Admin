using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface ICustomerBAL
    {
        ResultMessage Create(Customer entity);
        ResultMessage Update(Customer entity);
        ResultMessage Delete(int customerId);
        IQueryable<Customer> GetAll();
        Customer GetById(int customerId);
    }
}
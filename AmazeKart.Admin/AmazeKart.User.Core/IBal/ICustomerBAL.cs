using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;

namespace AmazeKart.User.Core.IBal
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
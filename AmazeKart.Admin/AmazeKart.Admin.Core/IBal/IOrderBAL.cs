using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IOrderBAL
    {
        ResultMessage Create(Order entity);
        ResultMessage Update(Order entity);
        ResultMessage Delete(int orderId);
        IQueryable<Order> GetAll();
        Order GetById(int orderId);
    }
}
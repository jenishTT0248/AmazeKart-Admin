using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
{
    public interface IOrderService
    {
        ResultMessage Create(Order order);
        ResultMessage Update(Order order);
        ResultMessage Delete(int orderId);
        Order GetById(int orderId);
        IQueryable<Order> GetAll();
    }
}
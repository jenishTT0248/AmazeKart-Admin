using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
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
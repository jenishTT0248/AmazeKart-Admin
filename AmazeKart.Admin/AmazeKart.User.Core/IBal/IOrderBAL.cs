using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;
using AmazeKart.User.Core.ViewModel.Response;

namespace AmazeKart.User.Core.IBal
{
    public interface IOrderBAL
    {
        ResultMessage Create(Order entity);
        ResultMessage Update(Order entity);
        ResultMessage Delete(int orderId);
        IQueryable<OrderResponse> GetAll();
        OrderResponse GetById(int orderId);
    }
}
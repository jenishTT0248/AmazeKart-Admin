using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;
using AmazeKart.Admin.Core.ViewModel.Response;

namespace AmazeKart.Admin.Core.IBal
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
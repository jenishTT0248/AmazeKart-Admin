using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;

namespace AmazeKart.User.Core.IBal
{
    public interface IOrderDetailBAL
    {
        ResultMessage SaveData(List<OrderDetail> entity);
        ResultMessage Delete(int orderId, int productId);
        IQueryable<OrderDetail> GetAll();
        List<OrderDetail> GetByOrderId(int orderId);
    }
}
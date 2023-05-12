using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
{
    public interface IOrderDetailService
    {
        ResultMessage SaveData(List<OrderDetail> orderDetail);
        ResultMessage Delete(int orderId, int productId);
        IQueryable<OrderDetail> GetByOrderId(int orderId);
        IQueryable<OrderDetail> GetAll();
    }
}
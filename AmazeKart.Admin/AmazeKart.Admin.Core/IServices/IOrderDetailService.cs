using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
{
    public interface IOrderDetailService
    {
        ResultMessage SaveData(List<OrderDetail> orderDetail);
        ResultMessage Delete(int orderId, int productId);
        IQueryable<OrderDetail> GetByOrderId(int orderId);
        IQueryable<OrderDetail> GetAll();
    }
}
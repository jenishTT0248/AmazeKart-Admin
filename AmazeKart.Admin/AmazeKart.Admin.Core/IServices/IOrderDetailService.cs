using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
{
    public interface IOrderDetailService
    {
        ResultMessage SaveData(OrderDetail orderDetail);
        ResultMessage Delete(int orderId, int productId);
        OrderDetail GetById(int orderId, int productId);
        IQueryable<OrderDetail> GetAll();
    }
}
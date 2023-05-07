using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IOrderDetailBAL
    {
        ResultMessage SaveData(List<OrderDetail> entity);
        ResultMessage Delete(int orderId, int productId);
        IQueryable<OrderDetail> GetAll();
        List<OrderDetail> GetByOrderId(int orderId);
    }
}
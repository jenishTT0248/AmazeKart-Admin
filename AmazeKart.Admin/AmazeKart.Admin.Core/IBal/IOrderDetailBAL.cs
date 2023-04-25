using AmazeKart.Admin.Core.Enums;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IOrderDetailBAL
    {
        ResultMessage SaveData(ViewModel.OrderDetail entity);
        ResultMessage Delete(int orderId, int productId);
        IQueryable<ViewModel.OrderDetail> GetAll();
        ViewModel.OrderDetail GetById(int orderId, int productId);
    }
}
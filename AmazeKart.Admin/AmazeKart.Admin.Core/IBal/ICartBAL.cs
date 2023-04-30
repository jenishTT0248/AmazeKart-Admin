using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface ICartBAL
    {
        ResultMessage Create(Cart entity);
        ResultMessage Update(Cart entity);
        ResultMessage Delete(int cartId);
        IQueryable<Cart> GetAll();
        Cart GetById(int cartId);
    }
}
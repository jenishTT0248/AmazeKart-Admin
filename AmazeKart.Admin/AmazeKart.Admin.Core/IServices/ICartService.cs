using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
{
    public interface ICartService
    {
        ResultMessage Create(Cart cart);
        ResultMessage Delete(int cartId);
        ResultMessage Update(Cart cart);
        IQueryable<Cart> GetAll();
        Cart GetById(int cartId);
    }
}
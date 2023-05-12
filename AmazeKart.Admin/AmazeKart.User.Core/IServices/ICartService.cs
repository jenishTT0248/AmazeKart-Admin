using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
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
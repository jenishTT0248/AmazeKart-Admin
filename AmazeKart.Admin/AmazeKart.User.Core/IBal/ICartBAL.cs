using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;
using AmazeKart.User.Core.ViewModel.Response;

namespace AmazeKart.User.Core.IBal
{
    public interface ICartBAL
    {
        ResultMessage Create(Cart entity);
        ResultMessage Update(Cart entity);
        ResultMessage Delete(int cartId);
        IQueryable<CartResponse> GetAll();
        CartResponse GetById(int cartId);
    }
}
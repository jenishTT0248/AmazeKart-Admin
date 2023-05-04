using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;
using ViewModelResponse = AmazeKart.Admin.Core.ViewModel.Response;

namespace AmazeKart.Admin.Core.IBal
{
    public interface ICartBAL
    {
        ResultMessage Create(Cart entity);
        ResultMessage Update(Cart entity);
        ResultMessage Delete(int cartId);
        IQueryable<ViewModelResponse.CartResponse> GetAll();
        ViewModelResponse.CartResponse GetById(int cartId);
    }
}
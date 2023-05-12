using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;
using AmazeKart.User.Core.ViewModel.Response;

namespace AmazeKart.User.Core.IBal
{
    public interface IProductBAL
    {
        ResultMessage Create(Product entity);
        ResultMessage Update(Product entity);
        ResultMessage Delete(int productId);
        IQueryable<ProductResponse> GetAll();
        ProductResponse GetById(int productId);
    }
}
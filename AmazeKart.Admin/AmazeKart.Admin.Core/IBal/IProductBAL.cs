using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;
using AmazeKart.Admin.Core.ViewModel.Response;

namespace AmazeKart.Admin.Core.IBal
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
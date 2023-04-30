using AmazeKart.Admin.Core.Enums;
using ViewModelResponse = AmazeKart.Admin.Core.ViewModel.Response;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IProductBAL
    {
        ResultMessage Create(ViewModel.Product entity);
        ResultMessage Update(ViewModel.Product entity);
        ResultMessage Delete(int productId);
        IQueryable<ViewModelResponse.ProductResponse> GetAll();
        ViewModelResponse.ProductResponse GetById(int productId);
    }
}
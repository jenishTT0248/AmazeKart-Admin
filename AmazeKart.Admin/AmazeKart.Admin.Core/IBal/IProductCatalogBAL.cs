using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;
using ViewModelResponse = AmazeKart.Admin.Core.ViewModel.Response;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IProductCatalogBAL
    {
        ResultMessage Create(ProductCatalog entity);
        ResultMessage Update(ProductCatalog entity);
        ResultMessage Delete(int productCatalogId);
        IQueryable<ViewModelResponse.ProductCatalogResponse> GetAll();
        ViewModelResponse.ProductCatalogResponse GetById(int categoryId);
    }
}
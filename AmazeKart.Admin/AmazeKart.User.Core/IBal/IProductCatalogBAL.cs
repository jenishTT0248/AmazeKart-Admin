using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;
using AmazeKart.User.Core.ViewModel.Response;

namespace AmazeKart.User.Core.IBal
{
    public interface IProductCatalogBAL
    {
        ResultMessage Create(ProductCatalog entity);
        ResultMessage Update(ProductCatalog entity);
        ResultMessage Delete(int productCatalogId);
        IQueryable<ProductCatalogResponse> GetAll();
        ProductCatalogResponse GetById(int categoryId);
    }
}
using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
{
    public interface IProductCatalogService
    {
        ResultMessage Create(ProductCatalog productCatalog);
        ResultMessage Update(ProductCatalog productCatalog);
        ResultMessage Delete(int productCatalogId);
        ProductCatalog GetById(int productCatalogId);
        IQueryable<ProductCatalog> GetAll();
    }
}
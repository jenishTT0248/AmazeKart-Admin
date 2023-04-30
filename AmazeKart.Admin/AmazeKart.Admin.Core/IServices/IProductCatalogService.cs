using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
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
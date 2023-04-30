using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IProductCatalogBAL
    {
        ResultMessage Create(ProductCatalog entity);
        ResultMessage Update(ProductCatalog entity);
        ResultMessage Delete(int productCatalogId);
        IQueryable<ProductCatalog> GetAll();
        ProductCatalog GetById(int categoryId);
    }
}
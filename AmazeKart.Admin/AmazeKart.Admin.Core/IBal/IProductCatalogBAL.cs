using AmazeKart.Admin.Core.Enums;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IProductCatalogBAL
    {
        ResultMessage Create(ViewModel.ProductCatalog entity);
        ResultMessage Update(ViewModel.ProductCatalog entity);
        ResultMessage Delete(ViewModel.ProductCatalog entity);
        IQueryable<ViewModel.ProductCatalog> GetAll();
        ViewModel.ProductCatalog GetById(int categoryId);
    }
}

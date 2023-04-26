using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
{
    public interface IProductService
    {
        ResultMessage Create(Product product);
        ResultMessage Update(Product product);
        ResultMessage Delete(int productId);
        Product GetById(int productId);
        IQueryable<Product> GetAll();
    }
}
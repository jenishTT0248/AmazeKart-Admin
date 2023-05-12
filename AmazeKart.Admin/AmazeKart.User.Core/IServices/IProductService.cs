using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
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
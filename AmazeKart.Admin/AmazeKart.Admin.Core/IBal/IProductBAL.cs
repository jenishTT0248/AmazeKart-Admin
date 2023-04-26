using AmazeKart.Admin.Core.Enums;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IProductBAL
    {
        ResultMessage Create(ViewModel.Product entity);
        ResultMessage Update(ViewModel.Product entity);
        ResultMessage Delete(int productId);
        IQueryable<ViewModel.Product> GetAll();
        ViewModel.Product GetById(int productId);
    }
}
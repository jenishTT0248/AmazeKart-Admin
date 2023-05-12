using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;

namespace AmazeKart.User.Core.IBal
{
    public interface ISupplierBAL
    {
        ResultMessage Create(Supplier entity);
        ResultMessage Update(Supplier entity);
        ResultMessage Delete(int supplierId);
        IQueryable<Supplier> GetAll();
        Supplier GetById(int supplierId);
    }
}
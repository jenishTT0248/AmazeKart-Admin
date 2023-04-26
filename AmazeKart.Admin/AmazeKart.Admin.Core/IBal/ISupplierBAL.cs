using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
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
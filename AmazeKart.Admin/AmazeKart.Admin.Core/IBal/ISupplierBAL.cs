using AmazeKart.Admin.Core.Enums;

namespace AmazeKart.Admin.Core.IBal
{
    public interface ISupplierBAL
    {
        ResultMessage Create(ViewModel.Supplier entity);
        ResultMessage Update(ViewModel.Supplier entity);
        ResultMessage Delete(int supplierId);
        IQueryable<ViewModel.Supplier> GetAll();
        ViewModel.Supplier GetById(int supplierId);
    }
}
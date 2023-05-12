using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;


namespace AmazeKart.User.Core.IServices
{
    public interface ISupplierService
    {
        ResultMessage Create(Supplier supplier);
        ResultMessage Update(Supplier supplier);
        ResultMessage Delete(int supplierId);
        Supplier GetById(int supplierId);
        IQueryable<Supplier> GetAll();
    }
}
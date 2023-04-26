using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;


namespace AmazeKart.Admin.Core.IServices
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
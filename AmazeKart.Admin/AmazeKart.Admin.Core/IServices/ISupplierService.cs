using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;


namespace AmazeKart.Admin.Core.IServices
{
    public class ISupplierService
    {
        ResultMessage Create(Supplier category);
        ResultMessage Update(Supplier category);
        ResultMessage Delete(int supplierId);
        Supplier GetById(int supplierId);
        IQueryable<Supplier> GetAll();
    }
}

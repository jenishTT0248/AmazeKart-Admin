using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
{
    public interface ISizeService
    {
        ResultMessage Create(Size size);
        ResultMessage Update(Size size);
        ResultMessage Delete(int sizeId);
        Size GetById(int sizeId);
        IQueryable<Size> GetAll();
    }
}
using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
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
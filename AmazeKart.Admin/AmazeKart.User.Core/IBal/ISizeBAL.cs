using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;

namespace AmazeKart.User.Core.IBal
{
    public interface ISizeBAL
    {
        ResultMessage Create(Size entity);
        ResultMessage Update(Size entity);
        ResultMessage Delete(int sizeId);
        IQueryable<Size> GetAll();
        Size GetById(int sizeId);
    }
}
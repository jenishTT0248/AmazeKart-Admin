using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
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
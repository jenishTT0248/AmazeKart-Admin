using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IColorBAL
    {
        ResultMessage Create(Color entity);
        ResultMessage Update(Color entity);
        ResultMessage Delete(int colorId);
        IQueryable<Color> GetAll();
        Color GetById(int colorId);
    }
}
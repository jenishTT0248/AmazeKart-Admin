using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;

namespace AmazeKart.User.Core.IBal
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
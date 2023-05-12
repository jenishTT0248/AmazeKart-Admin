using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
{
    public interface IColorService
    {
        ResultMessage Create(Color color);
        ResultMessage Delete(int colorId);
        ResultMessage Update(Color color);
        IQueryable<Color> GetAll();
        Color GetById(int colorId);
    }
}
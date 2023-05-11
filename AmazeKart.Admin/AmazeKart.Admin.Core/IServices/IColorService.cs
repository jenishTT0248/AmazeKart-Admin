using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
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
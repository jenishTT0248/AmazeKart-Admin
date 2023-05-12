using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
{
    public interface ICategoryService
    {
        ResultMessage Create(Category category);
        ResultMessage Update(Category category);
        ResultMessage Delete(int categoryId);
        Category GetById(int categoryId);
        IQueryable<Category> GetAll();
    }
}
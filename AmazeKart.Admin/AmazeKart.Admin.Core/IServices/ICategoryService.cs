using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
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
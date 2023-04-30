using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface ICategoryBAL
    {
        ResultMessage Create(Category entity);
        ResultMessage Update(Category entity);
        ResultMessage Delete(int categoryId);       
        IQueryable<Category> GetAll();
        Category GetById(int categoryId);
    }
}
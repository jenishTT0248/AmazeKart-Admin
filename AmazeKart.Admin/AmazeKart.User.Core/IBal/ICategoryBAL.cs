using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;

namespace AmazeKart.User.Core.IBal
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
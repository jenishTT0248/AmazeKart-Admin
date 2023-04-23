using AmazeKart.Admin.Core.Enums;

namespace AmazeKart.Admin.Core.IBal
{
    public interface ICategoryBAL
    {
        ResultMessage Create(ViewModel.Category entity);
        ResultMessage Update(ViewModel.Category entity);
        ResultMessage Delete(ViewModel.Category entity);
        IQueryable<ViewModel.Category> GetAll();
        ViewModel.Category GetById(int categoryId);
    }
}
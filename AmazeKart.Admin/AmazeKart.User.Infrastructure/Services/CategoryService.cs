using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
        }

        public ResultMessage Create(Category category)
        {
            if (category == null) return ResultMessage.RecordNotFound;

            bool isCategoryExists = _categoryRepository.Any(y => y.CategoryName == category.CategoryName && y.Active);

            if (isCategoryExists) return ResultMessage.RecordExists;

            category.Active = true;
            _categoryRepository.Create(category);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Update(Category category)
        {
            if (category == null) return ResultMessage.RecordNotFound;

            if (_categoryRepository.Any(x => x.Id != category.Id && x.CategoryName == category.CategoryName && x.Active))
            {
                return ResultMessage.RecordExists;
            }

            Category dbCategory = _categoryRepository.FindOne(x => x.Id == category.Id && x.Active);

            if (dbCategory == null) return ResultMessage.RecordNotFound;

            category.Active = true;
            _categoryRepository.SetValues(dbCategory, category);
            _categoryRepository.Update(dbCategory);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int categoryId)
        {
            Category dbCategory = _categoryRepository.FindOne(x => x.Id == categoryId && x.Active);

            if (dbCategory == null) return ResultMessage.RecordNotFound;

            _categoryRepository.Delete(dbCategory);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public Category GetById(int categoryId)
        {
            return _categoryRepository.FindOne(x => x.Id == categoryId && x.Active);
        }

        public IQueryable<Category> GetAll()
        {
            return _categoryRepository.Find(y=> y.Active);
        }
    }
}
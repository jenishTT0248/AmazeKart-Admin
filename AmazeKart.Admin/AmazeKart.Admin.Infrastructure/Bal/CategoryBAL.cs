using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class CategoryBAL : ICategoryBAL
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryBAL(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public ResultMessage Create(ViewModel.Category entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Category category = new ObjectModel.Category();
            _mapper.Map<ViewModel.Category, ObjectModel.Category>(entity, category);
            return _categoryService.Create(category);
        }

        public ResultMessage Update(ViewModel.Category entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Category category = new ObjectModel.Category();
            _mapper.Map<ViewModel.Category, ObjectModel.Category>(entity, category);
            return _categoryService.Update(category);
        }

        public ResultMessage Delete(int categoryId)
        {
            return _categoryService.Delete(categoryId);
        }

        public IQueryable<ViewModel.Category> GetAll()
        {
            var categories = _categoryService.GetAll().ToList();
            List<ViewModel.Category> categoryList = new();
            categoryList = _mapper.Map<List<ObjectModel.Category>, List<ViewModel.Category>>(categories);
            return categoryList.AsQueryable();
        }

        public ViewModel.Category GetById(int categoryId)
        {
            ObjectModel.Category category = _categoryService.GetById(categoryId);
            ViewModel.Category categoryViewModel = _mapper.Map<ObjectModel.Category, ViewModel.Category>(category);
            return categoryViewModel;
        }
    }
}
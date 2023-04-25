using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Infrastructure.Services;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class ProductCatalogBAL : IProductCatalogBAL
    {
        private readonly IMapper _mapper;
        private readonly IProductCatalogService _productCatalogService;
        public ProductCatalogBAL(IMapper mapper, IProductCatalogService productCatalogService)
        {
            _mapper = mapper;
            _productCatalogService = productCatalogService;
        }
        public ResultMessage Create(ViewModel.ProductCatalog entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.ProductCatalog productCatalog = new ObjectModel.ProductCatalog();
            _mapper.Map<ViewModel.ProductCatalog, ObjectModel.ProductCatalog>(entity, productCatalog);
            return _productCatalogService.Create(productCatalog);
        }

        public ResultMessage Delete(ViewModel.ProductCatalog entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.ProductCatalog productCatalog = new ObjectModel.ProductCatalog();
            _mapper.Map<ViewModel.ProductCatalog, ObjectModel.ProductCatalog>(entity, productCatalog);
            return _productCatalogService.Delete(productCatalog);
        }

        public IQueryable<ViewModel.ProductCatalog> GetAll()
        {
            var productCatalogs = _productCatalogService.GetAll().ToList();
            List<ViewModel.ProductCatalog> productCatalogsList = new();
            productCatalogsList = _mapper.Map<List<ObjectModel.ProductCatalog>, List<ViewModel.ProductCatalog>>(productCatalogs);
            return productCatalogsList.AsQueryable();
        }

        public ViewModel.ProductCatalog GetById(int productCatalogId)
        {
            ObjectModel.ProductCatalog productCatalog = _productCatalogService.GetById(productCatalogId);
            ViewModel.ProductCatalog productCatalogViewModel = _mapper.Map<ObjectModel.ProductCatalog, ViewModel.ProductCatalog>(productCatalog);
            return productCatalogViewModel;
        }

        public ResultMessage Update(ViewModel.ProductCatalog entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.ProductCatalog productCatalog = new ObjectModel.ProductCatalog();
            _mapper.Map<ViewModel.ProductCatalog, ObjectModel.ProductCatalog>(entity, productCatalog);
            return _productCatalogService.Update(productCatalog);
        }
    }
}

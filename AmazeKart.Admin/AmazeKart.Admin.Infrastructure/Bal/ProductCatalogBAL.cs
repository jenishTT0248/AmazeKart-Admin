using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;
using ViewModelResponse = AmazeKart.Admin.Core.ViewModel.Response;


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

        public ResultMessage Update(ViewModel.ProductCatalog entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.ProductCatalog productCatalog = new ObjectModel.ProductCatalog();
            _mapper.Map<ViewModel.ProductCatalog, ObjectModel.ProductCatalog>(entity, productCatalog);
            return _productCatalogService.Update(productCatalog);
        }

        public ResultMessage Delete(int productCatalogId)
        {
            return _productCatalogService.Delete(productCatalogId);
        }        

        public IQueryable<ViewModelResponse.ProductCatalogResponse> GetAll()
        {
            var productCatalogs = _productCatalogService.GetAll().ToList();
            List<ViewModelResponse.ProductCatalogResponse> productCatalogsList = new();
            productCatalogsList = _mapper.Map<List<ObjectModel.ProductCatalog>, List<ViewModelResponse.ProductCatalogResponse>>(productCatalogs);
            return productCatalogsList.AsQueryable();
        }      

        public ViewModelResponse.ProductCatalogResponse GetById(int productCatalogId)
        {
            ObjectModel.ProductCatalog productCatalog = _productCatalogService.GetById(productCatalogId);
            ViewModelResponse.ProductCatalogResponse productCatalogViewModel = _mapper.Map<ObjectModel.ProductCatalog, ViewModelResponse.ProductCatalogResponse>(productCatalog);
            return productCatalogViewModel;
        }
    }
}
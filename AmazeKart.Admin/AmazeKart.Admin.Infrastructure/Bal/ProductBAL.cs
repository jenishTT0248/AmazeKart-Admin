using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class ProductBAL : IProductBAL
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductBAL(IMapper mapper, IProductService productService)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public ResultMessage Create(ViewModel.Product entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Product product = new ObjectModel.Product();
            _mapper.Map<ViewModel.Product, ObjectModel.Product>(entity, product);
            return _productService.Create(product);
        }

        public ResultMessage Update(ViewModel.Product entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Product product = new ObjectModel.Product();
            _mapper.Map<ViewModel.Product, ObjectModel.Product>(entity, product);
            return _productService.Update(product);
        }

        public ResultMessage Delete(int productId)
        {
            return _productService.Delete(productId);
        }

        public IQueryable<ViewModel.Product> GetAll()
        {
            var products = _productService.GetAll().ToList();
            List<ViewModel.Product> productList = new();
            productList = _mapper.Map<List<ObjectModel.Product>, List<ViewModel.Product>>(products);
            return productList.AsQueryable();
        }

        public ViewModel.Product GetById(int productId)
        {
            ObjectModel.Product product = _productService.GetById(productId);
            ViewModel.Product productViewModel = _mapper.Map<ObjectModel.Product, ViewModel.Product>(product);
            return productViewModel;
        }
    }
}
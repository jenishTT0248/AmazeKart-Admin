using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCatalogRepository _productCatalogRepository;
        public ProductCatalogService(IProductCatalogRepository productCatalogRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productCatalogRepository = productCatalogRepository;   

        }
        public ResultMessage Create(ProductCatalog productCatalog)
        {
            if (productCatalog == null) return ResultMessage.RecordNotFound;
            bool isProductCatalogExists = _productCatalogRepository.Any(y => y.Product == productCatalog.Product);
            if (isProductCatalogExists) return ResultMessage.RecordExists;

            _productCatalogRepository.Create(productCatalog);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(ProductCatalog productCatalog)
        {
            if (productCatalog == null)
                return ResultMessage.RecordNotFound;

            ProductCatalog dbProductCatalog = _productCatalogRepository.FindOne(x => x.ProductId == productCatalog.ProductId);
            if (dbProductCatalog == null) return ResultMessage.RecordNotFound;

            _productCatalogRepository.Delete(dbProductCatalog);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public IQueryable<ProductCatalog> GetAll()
        {
            return _productCatalogRepository.All();
        }

        public ProductCatalog GetById(int productCatalogId)
        {
            return _productCatalogRepository.FindOne(x => x.ProductId == productCatalogId);
        }

        public ResultMessage Update(ProductCatalog productCatalog)
        {
            if (productCatalog == null) return ResultMessage.RecordNotFound;

            ProductCatalog dbProductCatalog = _productCatalogRepository.FindOne(x => x.ProductId == productCatalog.ProductId);
            if (dbProductCatalog == null) return ResultMessage.RecordNotFound;

            _productCatalogRepository.Update(dbProductCatalog);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }
    }
}

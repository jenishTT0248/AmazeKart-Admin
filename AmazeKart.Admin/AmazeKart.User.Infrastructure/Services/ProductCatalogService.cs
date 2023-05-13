using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
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
            
            bool isProductCatalogExists = _productCatalogRepository.Any(y => y.Id == productCatalog.Id);
            
            if (isProductCatalogExists) return ResultMessage.RecordExists;

            _productCatalogRepository.Create(productCatalog);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }
        
        public ResultMessage Update(ProductCatalog productCatalog)
        {
            if (productCatalog == null) return ResultMessage.RecordNotFound;

            if (_productCatalogRepository.Any(x => x.Id != productCatalog.Id && x.ProductId == productCatalog.ProductId))
            {
                return ResultMessage.RecordExists;
            }

            ProductCatalog dbProductCatalog = _productCatalogRepository.FindOne(x => x.ProductId == productCatalog.ProductId);
            if (dbProductCatalog == null) return ResultMessage.RecordNotFound;

            _productCatalogRepository.SetValues(dbProductCatalog, productCatalog);
            _productCatalogRepository.Update(dbProductCatalog);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int productCatalogId)
        {
            ProductCatalog dbProductCatalog = _productCatalogRepository.FindOne(x => x.Id == productCatalogId);
            
            if (dbProductCatalog == null) return ResultMessage.RecordNotFound;

            _productCatalogRepository.Delete(dbProductCatalog);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }
        
        public ProductCatalog GetById(int productCatalogId)
        {
            return _productCatalogRepository.FindOne(x => x.Id == productCatalogId);
        }

        public IQueryable<ProductCatalog> GetAll()
        {
            return _productCatalogRepository.All();
        }
    }
}
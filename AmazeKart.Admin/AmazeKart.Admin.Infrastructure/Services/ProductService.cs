using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public ResultMessage Create(Product product)
        {
            if (product == null) return ResultMessage.RecordNotFound;

            bool isProductExists = _productRepository.Any(y => y.SKU == product.SKU && y.Active);

            if (isProductExists) return ResultMessage.RecordExists;

            _productRepository.Create(product);
            _unitOfWork.Commit();
            
            return ResultMessage.Success;
        }

        public ResultMessage Update(Product product)
        {
            if (product == null) return ResultMessage.RecordNotFound;

            if (_productRepository.Any(x => x.Id != product.Id && x.SKU == product.SKU && x.Active))
            {
                return ResultMessage.RecordExists;
            }

            Product dbProduct = _productRepository.FindOne(x => x.Id == product.Id && x.Active);
            if (dbProduct == null) return ResultMessage.RecordNotFound;

            _productRepository.SetValues(dbProduct, product);
            _productRepository.Update(dbProduct);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int productId)
        {
            Product dbProduct = _productRepository.FindOne(x => x.Id == productId && x.Active);
            if (dbProduct == null) return ResultMessage.RecordNotFound;

            _productRepository.Delete(dbProduct);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public Product GetById(int productId)
        {
            return _productRepository.FindOne(x => x.Id == productId && x.Active);
        }

        public IQueryable<Product> GetAll()
        {
            return _productRepository.Find(x => x.Active);
        }
    }
}
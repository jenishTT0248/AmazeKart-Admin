using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductDetailRepository _productDetailRepository;
        public ProductDetailService(IUnitOfWork unitOfWork, IProductDetailRepository productDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _productDetailRepository = productDetailRepository;
        }

        public ResultMessage Create(ProductDetail productDetail)
        {
            if (productDetail == null) return ResultMessage.RecordNotFound;

            //bool isProductExists = _productRepository.Any(y => y.SKU == product.SKU && y.Active);
            //if (isProductExists) return ResultMessage.RecordExists;

            _productDetailRepository.Create(productDetail);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }
    }
}

using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;


namespace AmazeKart.Admin.Infrastructure.Repositories
{
    public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}
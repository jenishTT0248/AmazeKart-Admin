using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.ObjectModel;


namespace AmazeKart.User.Infrastructure.Repositories
{
    public class ProductDetailRepository : Repository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}
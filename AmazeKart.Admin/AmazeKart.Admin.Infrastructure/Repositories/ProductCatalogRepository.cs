using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Repositories
{
    public class ProductCatalogRepository : Repository<ProductCatalog>, IProductCatalogRepository
    {
        public ProductCatalogRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}

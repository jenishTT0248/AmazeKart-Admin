using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}
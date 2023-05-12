using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}
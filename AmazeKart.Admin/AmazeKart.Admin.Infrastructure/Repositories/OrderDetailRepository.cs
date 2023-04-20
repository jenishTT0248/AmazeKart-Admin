using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}

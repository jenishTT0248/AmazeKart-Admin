using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Repositories
{
    public class AdminUserRepository : Repository<AdminUser>, IAdminUserRepository
    {
        public AdminUserRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}

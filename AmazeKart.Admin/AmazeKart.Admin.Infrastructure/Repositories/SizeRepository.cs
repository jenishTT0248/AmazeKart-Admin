using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Repositories
{
    public class SizeRepository : Repository<Size>, ISizeRepository
    {
        public SizeRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}
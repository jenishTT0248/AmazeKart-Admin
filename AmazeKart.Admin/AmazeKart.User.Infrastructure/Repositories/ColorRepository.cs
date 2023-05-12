using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Repositories
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}
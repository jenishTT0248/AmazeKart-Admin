using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public AmazeKartDB dbContext { get; set; }

        public UnitOfWork(AmazeKartDB databaseContext)
        {
            this.dbContext = databaseContext;
        }

        public void Commit()
        {
            try
            {                
                dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Repositories
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
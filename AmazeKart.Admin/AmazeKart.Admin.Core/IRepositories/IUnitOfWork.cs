using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IRepositories
{
    public interface IUnitOfWork
    {
        AmazeKartDB dbContext { get; set; }
        void Commit();
    }
}
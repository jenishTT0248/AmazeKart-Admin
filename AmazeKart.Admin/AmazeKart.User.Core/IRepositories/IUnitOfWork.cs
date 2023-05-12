using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IRepositories
{
    public interface IUnitOfWork
    {
        AmazeKartDB dbContext { get; set; }
        void Commit();
    }
}
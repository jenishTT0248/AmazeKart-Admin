using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Repositories
{
    public class PaymentDetailRepository : Repository<PaymentDetail>, IPaymentDetailRepository
    {
        public PaymentDetailRepository(IUnitOfWork context)
            : base(context)
        {
        }
    }
}
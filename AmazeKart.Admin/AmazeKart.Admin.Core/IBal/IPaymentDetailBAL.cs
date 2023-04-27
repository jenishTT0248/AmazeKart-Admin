using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IPaymentDetailBAL
    {
        ResultMessage Create(PaymentDetail entity);
        ResultMessage Update(PaymentDetail entity);
        ResultMessage Delete(int paymentId);
        IQueryable<PaymentDetail> GetAll();
        PaymentDetail GetById(int paymentId);
    }
}
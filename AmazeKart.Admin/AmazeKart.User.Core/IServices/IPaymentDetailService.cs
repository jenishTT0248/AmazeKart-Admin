using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Core.IServices
{
    public interface IPaymentDetailService
    {
        ResultMessage Create(PaymentDetail paymentTDetail);
        ResultMessage Update(PaymentDetail paymentTDetail);
        ResultMessage Delete(int paymentId);
        PaymentDetail GetById(int paymentId);
        IQueryable<PaymentDetail> GetAll();
    }
}
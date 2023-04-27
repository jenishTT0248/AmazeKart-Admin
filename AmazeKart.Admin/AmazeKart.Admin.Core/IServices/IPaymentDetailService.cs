using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
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
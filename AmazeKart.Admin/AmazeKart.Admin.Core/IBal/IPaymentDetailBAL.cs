using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;
using AmazeKart.Admin.Core.ViewModel.Response;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IPaymentDetailBAL
    {
        ResultMessage Create(PaymentDetail entity);
        ResultMessage Update(PaymentDetail entity);
        ResultMessage Delete(int paymentId);
        IQueryable<PaymentDetailResponse> GetAll();
        PaymentDetailResponse GetById(int paymentId);
    }
}
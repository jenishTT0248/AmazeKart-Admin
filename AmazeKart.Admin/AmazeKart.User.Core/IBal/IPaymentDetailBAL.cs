using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.ViewModel;
using AmazeKart.User.Core.ViewModel.Response;

namespace AmazeKart.User.Core.IBal
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
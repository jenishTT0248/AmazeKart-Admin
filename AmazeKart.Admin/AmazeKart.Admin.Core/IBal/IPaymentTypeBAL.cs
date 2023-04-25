using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IPaymentTypeBAL
    {
        ResultMessage Create(PaymentType entity);
        ResultMessage Update(PaymentType entity);
        ResultMessage Delete(int paymentId);
        IQueryable<PaymentType> GetAll();
        PaymentType GetById(int paymentId);
    }
}
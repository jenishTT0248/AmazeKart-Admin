using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
{
    public interface IPaymentTypeService
    {
        ResultMessage Create(PaymentType paymentType);
        ResultMessage Update(PaymentType paymentType);
        ResultMessage Delete(int paymentId);
        PaymentType GetById(int paymentId);
        IQueryable<PaymentType> GetAll();
    }
}
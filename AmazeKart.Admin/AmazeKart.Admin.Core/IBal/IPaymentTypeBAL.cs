using AmazeKart.Admin.Core.Enums;

namespace AmazeKart.Admin.Core.IBal
{
    public interface IPaymentTypeBAL
    {
        ResultMessage Create(ViewModel.PaymentType entity);
        ResultMessage Update(ViewModel.PaymentType entity);
        ResultMessage Delete(ViewModel.PaymentType entity);
        IQueryable<ViewModel.PaymentType> GetAll();
        ViewModel.PaymentType GetById(int paymentId);
    }
}
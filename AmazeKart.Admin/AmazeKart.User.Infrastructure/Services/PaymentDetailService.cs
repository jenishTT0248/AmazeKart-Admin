using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
{
    public class PaymentDetailService : IPaymentDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentDetailRepository _paymentDetailRepository;

        public PaymentDetailService(IUnitOfWork unitOfWork, IPaymentDetailRepository paymentDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _paymentDetailRepository = paymentDetailRepository;
        }

        public ResultMessage Create(PaymentDetail paymentDetail)
        {
            if (paymentDetail == null) return ResultMessage.RecordNotFound;

            bool isPaymentDetailExists = _paymentDetailRepository.Any(y => y.Id == paymentDetail.Id);

            if (isPaymentDetailExists) return ResultMessage.RecordExists;

            _paymentDetailRepository.Create(paymentDetail);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Update(PaymentDetail paymentDetail)
        {
            if (paymentDetail == null) return ResultMessage.RecordNotFound;

            PaymentDetail dbPaymentDetail = _paymentDetailRepository.FindOne(x => x.Id == paymentDetail.Id);
            if (dbPaymentDetail == null) return ResultMessage.RecordNotFound;

            _paymentDetailRepository.SetValues(dbPaymentDetail, paymentDetail);
            _paymentDetailRepository.Update(dbPaymentDetail);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int paymentId)
        {
            PaymentDetail dbPaymentDetail = _paymentDetailRepository.FindOne(x => x.Id == paymentId);
                
            if (dbPaymentDetail == null) return ResultMessage.RecordNotFound;

            _paymentDetailRepository.Delete(dbPaymentDetail);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public PaymentDetail GetById(int paymentId)
        {
            return _paymentDetailRepository.FindOne(x => x.Id == paymentId);
        }

        public IQueryable<PaymentDetail> GetAll()
        {
            return _paymentDetailRepository.All();
        }
    }
}
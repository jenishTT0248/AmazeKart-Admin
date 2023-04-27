using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class PaymentDetailBAL : IPaymentDetailBAL
    {
        private readonly IPaymentDetailService _paymentDetailService;
        private readonly IMapper _mapper;

        public PaymentDetailBAL(IMapper mapper, IPaymentDetailService paymentDetailService)
        {
            _mapper = mapper;
            _paymentDetailService = paymentDetailService;
        }

        public ResultMessage Create(ViewModel.PaymentDetail entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.PaymentDetail paymentDetail = new ObjectModel.PaymentDetail();
            _mapper.Map<ViewModel.PaymentDetail, ObjectModel.PaymentDetail>(entity, paymentDetail);
            return _paymentDetailService.Create(paymentDetail);
        }

        public ResultMessage Update(ViewModel.PaymentDetail entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.PaymentDetail paymentDetail = new ObjectModel.PaymentDetail();
            _mapper.Map<ViewModel.PaymentDetail, ObjectModel.PaymentDetail>(entity, paymentDetail);
            return _paymentDetailService.Update(paymentDetail);
        }

        public ResultMessage Delete(int paymentId)
        {
            return _paymentDetailService.Delete(paymentId);
        }

        public IQueryable<ViewModel.PaymentDetail> GetAll()
        {            
            var paymentDetails = _paymentDetailService.GetAll().ToList();
            List<ViewModel.PaymentDetail> paymentDetailList = new();
            paymentDetailList = _mapper.Map<List<ObjectModel.PaymentDetail>, List<ViewModel.PaymentDetail>>(paymentDetails);
            return paymentDetailList.AsQueryable();
        }

        public ViewModel.PaymentDetail GetById(int paymentId)
        {
            ObjectModel.PaymentDetail paymentDetail = _paymentDetailService.GetById(paymentId);
            ViewModel.PaymentDetail paymentDetailViewModel = _mapper.Map<ObjectModel.PaymentDetail, ViewModel.PaymentDetail>(paymentDetail);
            return paymentDetailViewModel;
        }
    }
}
using AmazeKart.User.Core;
using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IBal;
using AmazeKart.User.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.User.Core.ObjectModel;
using ViewModel = AmazeKart.User.Core.ViewModel;
using ViewModelResponse = AmazeKart.User.Core.ViewModel.Response;

namespace AmazeKart.User.Infrastructure.Bal
{
    public class PaymentDetailBAL : IPaymentDetailBAL
    {
        private readonly IPaymentDetailService _paymentDetailService;
        private readonly IMapper _mapper;
        private readonly IAmazeKartAdminServiceBus _amazeKartAdminServiceBus;

        public PaymentDetailBAL(IMapper mapper, IPaymentDetailService paymentDetailService, IAmazeKartAdminServiceBus amazeKartAdminServiceBus)
        {
            _mapper = mapper;
            _paymentDetailService = paymentDetailService;
            _amazeKartAdminServiceBus = amazeKartAdminServiceBus;
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

        public IQueryable<ViewModelResponse.PaymentDetailResponse> GetAll()
        {            
            var paymentDetails = _paymentDetailService.GetAll().ToList();
            List<ViewModelResponse.PaymentDetailResponse> paymentDetailList = new();
            paymentDetailList = _mapper.Map<List<ObjectModel.PaymentDetail>, List<ViewModelResponse.PaymentDetailResponse>>(paymentDetails);
            return paymentDetailList.AsQueryable();
        }

        public ViewModelResponse.PaymentDetailResponse GetById(int paymentId)
        {
            ObjectModel.PaymentDetail paymentDetail = _paymentDetailService.GetById(paymentId);
            ViewModelResponse.PaymentDetailResponse paymentDetailViewModel = _mapper.Map<ObjectModel.PaymentDetail, ViewModelResponse.PaymentDetailResponse>(paymentDetail);
            return paymentDetailViewModel;
        }
    }
}
using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class PaymentTypeBAL : IPaymentTypeBAL
    {
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly IMapper _mapper;

        public PaymentTypeBAL(IMapper mapper, IPaymentTypeService paymentTypeService)
        {
            _mapper = mapper;
            _paymentTypeService =   paymentTypeService;
        }

        public ResultMessage Create(ViewModel.PaymentType entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.PaymentType paymentType = new ObjectModel.PaymentType();
            _mapper.Map<ViewModel.PaymentType, ObjectModel.PaymentType>(entity, paymentType);
            return _paymentTypeService.Create(paymentType);
        }

        public ResultMessage Update(ViewModel.PaymentType entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.PaymentType paymentType = new ObjectModel.PaymentType();
            _mapper.Map<ViewModel.PaymentType, ObjectModel.PaymentType>(entity, paymentType);
            return _paymentTypeService.Update(paymentType);
        }


        public ResultMessage Delete(int paymentId)
        {
            return _paymentTypeService.Delete(paymentId);
        }

        public IQueryable<ViewModel.PaymentType> GetAll()
        {
            var paymentTypes = _paymentTypeService.GetAll().ToList();
            List<ViewModel.PaymentType> paymentTypesList = new();
            paymentTypesList = _mapper.Map<List<ObjectModel.PaymentType>, List<ViewModel.PaymentType>>(paymentTypes);
            return paymentTypesList.AsQueryable();
        }

        public ViewModel.PaymentType GetById(int paymentId)
        {
            ObjectModel.PaymentType paymentType = _paymentTypeService.GetById(paymentId);
            ViewModel.PaymentType paymentTypeViewModel = _mapper.Map<ObjectModel.PaymentType, ViewModel.PaymentType>(paymentType);
            return paymentTypeViewModel;
        }
    }
}
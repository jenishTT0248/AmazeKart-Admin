using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class OrderDetailBAL : IOrderDetailBAL
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailBAL(IMapper mapper, IOrderDetailService orderDetailService)
        {
            _mapper = mapper;
            _orderDetailService = orderDetailService;
        }

        public ResultMessage SaveData(ViewModel.OrderDetail entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.OrderDetail orderDetail = new ObjectModel.OrderDetail();
            _mapper.Map<ViewModel.OrderDetail, ObjectModel.OrderDetail>(entity, orderDetail);
            return _orderDetailService.SaveData(orderDetail);
        }

        public ResultMessage Delete(int orderId, int productId)
        {            
            return _orderDetailService.Delete(orderId, productId);
        }

        public IQueryable<ViewModel.OrderDetail> GetAll()
        {
            var orderDetails = _orderDetailService.GetAll().ToList();
            List<ViewModel.OrderDetail> orderDetailList = new();
            orderDetailList = _mapper.Map<List<ObjectModel.OrderDetail>, List<ViewModel.OrderDetail>>(orderDetails);
            return orderDetailList.AsQueryable();
        }

        public ViewModel.OrderDetail GetById(int orderId, int productId)
        {
            ObjectModel.OrderDetail orderDetail = _orderDetailService.GetById(orderId, productId);
            ViewModel.OrderDetail orderDetailViewModel = _mapper.Map<ObjectModel.OrderDetail, ViewModel.OrderDetail>(orderDetail);
            return orderDetailViewModel;
        }        
    }
}
using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IBal;
using AmazeKart.User.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.User.Core.ObjectModel;
using ViewModel = AmazeKart.User.Core.ViewModel;

namespace AmazeKart.User.Infrastructure.Bal
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

        public ResultMessage SaveData(List<ViewModel.OrderDetail> entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            List<ObjectModel.OrderDetail> orderDetail = new List<ObjectModel.OrderDetail>();
            _mapper.Map<List<ViewModel.OrderDetail>, List<ObjectModel.OrderDetail>>(entity, orderDetail);
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

        public List<ViewModel.OrderDetail> GetByOrderId(int orderId)
        {
            var orderDetail = _orderDetailService.GetByOrderId(orderId).ToList();
            List<ViewModel.OrderDetail> orderDetailViewModel = _mapper.Map<List<ObjectModel.OrderDetail>, List<ViewModel.OrderDetail>>(orderDetail);
            return orderDetailViewModel;
        }        
    }
}
using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class OrderBAL : IOrderBAL
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderBAL(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        public ResultMessage Create(ViewModel.Order entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Order order = new ObjectModel.Order();
            _mapper.Map<ViewModel.Order, ObjectModel.Order>(entity, order);
            return _orderService.Create(order);
        }

        public ResultMessage Delete(int orderId)
        {
            return _orderService.Delete(orderId);
        }

        public IQueryable<ViewModel.Order> GetAll()
        {
            var orders = _orderService.GetAll().ToList();
            List<ViewModel.Order> orderList = new();
            orderList = _mapper.Map<List<ObjectModel.Order>, List<ViewModel.Order>>(orders);
            return orderList.AsQueryable();
        }

        public ViewModel.Order GetById(int orderId)
        {
            ObjectModel.Order order = _orderService.GetById(orderId);
            ViewModel.Order orderViewModel = _mapper.Map<ObjectModel.Order, ViewModel.Order>(order);
            return orderViewModel;
        }

        public ResultMessage Update(ViewModel.Order entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Order order = new ObjectModel.Order();
            _mapper.Map<ViewModel.Order, ObjectModel.Order>(entity, order);
            return _orderService.Update(order);
        }
    }
}

﻿using AmazeKart.User.Core;
using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IBal;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

﻿using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IBal;
using AmazeKart.User.Core.IServices;

using AutoMapper;
using ObjectModel = AmazeKart.User.Core.ObjectModel;
using ViewModel = AmazeKart.User.Core.ViewModel;
using ViewModelResponse = AmazeKart.User.Core.ViewModel.Response;

namespace AmazeKart.User.Infrastructure.Bal
{
    public class OrderBAL : IOrderBAL
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        private readonly IAmazeKartAdminServiceBus _amazeKartAdminServiceBus;

        public OrderBAL(IMapper mapper, IOrderService orderService, IAmazeKartAdminServiceBus amazeKartAdminServiceBus)
        {
            _mapper = mapper;
            _orderService = orderService;
            _amazeKartAdminServiceBus = amazeKartAdminServiceBus;


        public OrderBAL(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;

        }

        public ResultMessage Create(ViewModel.Order entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;


            //ObjectModel.Order order = new ObjectModel.Order();
            //_mapper.Map<ViewModel.Order, ObjectModel.Order>(entity, order);
            //return _orderService.Create(order);

            _amazeKartAdminServiceBus.Publish<Order>(new { Order = entity });
            return ResultMessage.Success;

            ObjectModel.Order order = new ObjectModel.Order();
            _mapper.Map<ViewModel.Order, ObjectModel.Order>(entity, order);
            return _orderService.Create(order);

        }

        public ResultMessage Delete(int orderId)
        {
            return _orderService.Delete(orderId);
        }

        public IQueryable<ViewModelResponse.OrderResponse> GetAll()
        {
            var orders = _orderService.GetAll().ToList();
            List<ViewModelResponse.OrderResponse> orderList = new();
            orderList = _mapper.Map<List<ObjectModel.Order>, List<ViewModelResponse.OrderResponse>>(orders);
            return orderList.AsQueryable();
        }

        public ViewModelResponse.OrderResponse GetById(int orderId)
        {
            ObjectModel.Order order = _orderService.GetById(orderId);
            ViewModelResponse.OrderResponse orderViewModel = _mapper.Map<ObjectModel.Order, ViewModelResponse.OrderResponse>(order);
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
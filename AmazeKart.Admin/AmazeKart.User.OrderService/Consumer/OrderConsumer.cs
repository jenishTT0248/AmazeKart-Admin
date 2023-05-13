using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;
using AmazeKart.User.OrderService.DataContract;
using AutoMapper;
using log4net;
//using log4net;
using MassTransit;

namespace AmazeKart.User.OrderService.Consumer
{
    public class OrderConsumer : IConsumer<Orders>
    {
        private readonly ILog _logger;
        private readonly IMapper _mapper;

        private readonly IOrderService _orderService;

        public OrderConsumer(IOrderService orderService, ILog logger,IMapper mapper)
        {
            _orderService = orderService;
            _logger = LogManager.GetLogger(typeof(OrderConsumer)); 
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<Orders> context)
        {
           _logger.Info("Order Service Started");
            var orders = _mapper.Map<Orders, Order>(context.Message);
           
            _orderService.Create(orders);
           _logger.Info("Order Service End");
        }
    }
}

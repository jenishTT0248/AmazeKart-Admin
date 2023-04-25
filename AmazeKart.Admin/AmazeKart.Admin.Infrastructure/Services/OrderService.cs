using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IUnitOfWork unitOfWork, IOrderRepository orderRepository)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }

        public ResultMessage Create(Order order)
        {
            if (order == null) return ResultMessage.RecordNotFound;
            
            bool isOrderExists = _orderRepository.Any(y => y.Id == order.Id);
            
            if (isOrderExists) return ResultMessage.RecordExists;

            _orderRepository.Create(order);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int orderId)
        {
            Order dbOrder = _orderRepository.FindOne(x => x.Id == orderId);
            if (dbOrder == null) return ResultMessage.RecordNotFound;

            _orderRepository.Delete(dbOrder);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public IQueryable<Order> GetAll()
        {
            return _orderRepository.All();
        }

        public Order GetById(int orderId)
        {
            return _orderRepository.FindOne(x => x.Id == orderId);
        }

        public ResultMessage Update(Order order)
        {
            if (order == null) return ResultMessage.RecordNotFound;

            Order dbOrder = _orderRepository.FindOne(x => x.Id == order.Id);            
            if (dbOrder == null) return ResultMessage.RecordNotFound;

            _orderRepository.SetValues(dbOrder, order);
            _orderRepository.Update(dbOrder);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }
    }
}
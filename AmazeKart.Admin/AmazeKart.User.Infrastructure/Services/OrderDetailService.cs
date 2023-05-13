using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IUnitOfWork unitOfWork, IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public ResultMessage SaveData(List<OrderDetail> orderDetail)
        {
            if (orderDetail == null) return ResultMessage.RecordNotFound;

            foreach (var order in orderDetail)
            {
                OrderDetail dbOrderDetail = _orderDetailRepository.FindOne(x => x.OrderId == order.OrderId && x.ProductId == order.ProductId);

                if (dbOrderDetail == null)
                {
                    _orderDetailRepository.Create(order);
                }
                else
                {
                    _orderDetailRepository.SetValues(dbOrderDetail, orderDetail);
                    _orderDetailRepository.Update(dbOrderDetail);
                }
            }

            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int orderId, int productId)
        {
            OrderDetail dbOrder = _orderDetailRepository.FindOne(x => x.OrderId == orderId && x.ProductId == productId);
            if (dbOrder == null) return ResultMessage.RecordNotFound;

            _orderDetailRepository.Delete(dbOrder);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public IQueryable<OrderDetail> GetAll()
        {
            return _orderDetailRepository.All();
        }

        public IQueryable<OrderDetail> GetByOrderId(int orderId)
        {
            return _orderDetailRepository.Find(x => x.OrderId == orderId);
        }
    }
}
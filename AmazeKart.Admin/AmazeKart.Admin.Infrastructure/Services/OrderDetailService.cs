using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Infrastructure.Services
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

        public ResultMessage SaveData(OrderDetail orderDetail)
        {
            if (orderDetail == null) return ResultMessage.RecordNotFound;

            OrderDetail dbOrderDetail = _orderDetailRepository.FindOne(x => x.OrderId == orderDetail.OrderId && x.ProductId == orderDetail.ProductId);

            if (dbOrderDetail == null)
            {
                _orderDetailRepository.Create(orderDetail);
            }
            else
            {
                _orderDetailRepository.SetValues(dbOrderDetail, orderDetail);
                _orderDetailRepository.Update(dbOrderDetail);
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

        public OrderDetail GetById(int orderId, int productId)
        {
            return _orderDetailRepository.FindOne(x => x.OrderId == orderId && x.ProductId == productId);
        }
    }
}
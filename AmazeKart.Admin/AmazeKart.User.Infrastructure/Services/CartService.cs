using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IRepositories;
using AmazeKart.User.Core.IServices;
using AmazeKart.User.Core.ObjectModel;

namespace AmazeKart.User.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
        }

        public ResultMessage Create(Cart cart)
        {
            if (cart == null) return ResultMessage.RecordNotFound;
            
            bool isCartExists = _cartRepository.Any(y => y.Id == cart.Id);
            
            if (isCartExists)
                return ResultMessage.RecordExists;

            _cartRepository.Create(cart);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public ResultMessage Delete(int cartId)
        {
            Cart dbCart = _cartRepository.FindOne(x => x.Id == cartId);
            if (dbCart == null) return ResultMessage.RecordNotFound;

            _cartRepository.Delete(dbCart);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }

        public IQueryable<Cart> GetAll()
        {
            return _cartRepository.All();
        }

        public Cart GetById(int cartId)
        {
            return _cartRepository.FindOne(x => x.Id == cartId);
        }

        public ResultMessage Update(Cart cart)
        {
            if (cart == null) return ResultMessage.RecordNotFound;

            Cart dbCart = _cartRepository.FindOne(x => x.Id == cart.Id);
            if (dbCart == null) return ResultMessage.RecordNotFound;

            _cartRepository.SetValues(dbCart, cart);
            _cartRepository.Update(dbCart);
            _unitOfWork.Commit();
            return ResultMessage.Success;
        }
    }
}
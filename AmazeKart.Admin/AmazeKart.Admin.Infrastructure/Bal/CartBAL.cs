using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.IServices;
using AutoMapper;
using ObjectModel = AmazeKart.Admin.Core.ObjectModel;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

namespace AmazeKart.Admin.Infrastructure.Bal
{
    public class CartBAL : ICartBAL
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        public CartBAL(IMapper mapper, ICartService cartService)
        {
            _mapper = mapper;
            _cartService = cartService;
        }

        public ResultMessage Create(ViewModel.Cart entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Cart cart = new ObjectModel.Cart();
            _mapper.Map<ViewModel.Cart, ObjectModel.Cart>(entity, cart);
            return _cartService.Create(cart);
        }

        public ResultMessage Update(ViewModel.Cart entity)
        {
            if (entity == null) return ResultMessage.RecordNotFound;

            ObjectModel.Cart cart = new ObjectModel.Cart();
            _mapper.Map<ViewModel.Cart, ObjectModel.Cart>(entity, cart);
            return _cartService.Update(cart);
        }

        public ResultMessage Delete(int cartId)
        {
            return _cartService.Delete(cartId);
        }

        public IQueryable<ViewModel.Cart> GetAll()
        {
            var cartData = _cartService.GetAll().ToList();
            List<ViewModel.Cart> cartViewModel = new();
            cartViewModel = _mapper.Map<List<ObjectModel.Cart>, List<ViewModel.Cart>>(cartData);
            return cartViewModel.AsQueryable();
        }

        public ViewModel.Cart GetById(int cartId)
        {
            ObjectModel.Cart cart = _cartService.GetById(cartId);
            ViewModel.Cart cartViewModel = _mapper.Map<ObjectModel.Cart, ViewModel.Cart>(cart);
            return cartViewModel;
        }
    }
}
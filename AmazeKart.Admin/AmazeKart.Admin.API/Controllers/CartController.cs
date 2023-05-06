using AmazeKart.Admin.API.Helpers;
using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using AmazeKart.Admin.Core.ViewModel.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/Cart")]
    public class CartController : BaseAPIController
    {
        private readonly ICartBAL _cartBAL;

        public CartController(ICartBAL cartBAL)
        {
            _cartBAL = cartBAL;
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(Cart entity)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, ModelState.GetInvalidModelStateErrors(), null, MessageType.Warning.GetStringValue()));
            }

            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage;

            if (entity.Id == 0)
            {
                resultMessage = MessageConstants.RecordInsertSuccessfully;
                rMsg = _cartBAL.Create(entity);
            }
            else
            {
                resultMessage = MessageConstants.RecordupdateSuccessfully;
                rMsg = _cartBAL.Update(entity);
            }

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpPost, Route("DeleteData")]
        public IActionResult DeleteData(int cartId)
        {
            if (cartId <= 0)
            {
                ResultMessage notFoundMessage = ResultMessage.NotFound;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, notFoundMessage.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage = MessageConstants.RecordDeleteSuccessfully;
            rMsg = _cartBAL.Delete(cartId);

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));

            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<CartResponse> cartList = _cartBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, cartList, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int cartId)
        {
            if (cartId <= 0)
            {
                ResultMessage notFoundMessage = ResultMessage.NotFound;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, notFoundMessage.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            CartResponse cart = _cartBAL.GetById(cartId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, cart, MessageType.Success.GetStringValue()));
        }
    }
}
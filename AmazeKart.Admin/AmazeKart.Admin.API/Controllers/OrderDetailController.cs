using AmazeKart.Admin.API.Helpers;
using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/OrderDetail")]
    public class OrderDetailController : BaseAPIController
    {
        private readonly IOrderDetailBAL _orderDetailBAL;

        public OrderDetailController(IOrderDetailBAL orderDetailBAL)
        {
            _orderDetailBAL = orderDetailBAL;
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(List<OrderDetail> orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, ModelState.GetInvalidModelStateErrors(), null, MessageType.Warning.GetStringValue()));
            }

            ResultMessage rMsg = ResultMessage.RecordNotFound;
            rMsg = _orderDetailBAL.SaveData(orderDetail);
            
            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            
            return Ok(new ResponseResult(HttpStatusCode.OK, rMsg.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpPost, Route("DeleteData")]
        public IActionResult DeleteData(int orderId, int productId)
        {
            if (orderId <= 0 || productId <= 0)
            {
                ResultMessage invalidDetail = ResultMessage.InvalidOrderDetail;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, invalidDetail.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage = MessageConstants.RecordDeleteSuccessfully;
            rMsg = _orderDetailBAL.Delete(orderId, productId);

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));

            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<OrderDetail> orderDetailList = _orderDetailBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, orderDetailList, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetByOrderId")]
        public IActionResult GetByOrderId(int orderId)
        {
            if (orderId <= 0)
            {
                ResultMessage invalidDetail = ResultMessage.InvalidOrderDetail;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, invalidDetail.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            List<OrderDetail> orderDetail = _orderDetailBAL.GetByOrderId(orderId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, orderDetail, MessageType.Success.GetStringValue()));
        }
    }
}
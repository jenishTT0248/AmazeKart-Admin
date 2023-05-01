using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ViewModel = AmazeKart.Admin.Core.ViewModel;

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
        public IActionResult SaveData(ViewModel.OrderDetail orderDetail)
        {
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            rMsg = _orderDetailBAL.SaveData(orderDetail);
            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            return Ok(new ResponseResult(HttpStatusCode.OK, rMsg.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpPost, Route("DeleteData")]
        public IActionResult DeleteData(int orderId, int productId)
        {
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
            List<ViewModel.OrderDetail> orderDetailList = _orderDetailBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, orderDetailList, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int orderId, int productId)
        {
            ViewModel.OrderDetail orderDetail = _orderDetailBAL.GetById(orderId, productId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, orderDetail, MessageType.Success.GetStringValue()));
        }
    }
}
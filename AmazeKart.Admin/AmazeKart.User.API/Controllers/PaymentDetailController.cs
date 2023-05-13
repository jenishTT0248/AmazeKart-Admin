using AmazeKart.User.API.Helpers;
using AmazeKart.User.Core.Enums;
using AmazeKart.User.Core.IBal;
using AmazeKart.User.Core.ViewModel;
using AmazeKart.User.Core.ViewModel.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.User.API.Controllers
{
    [Route("api/PaymentDetail")]
    public class PaymentDetailController : BaseAPIController
    {            
        private readonly IPaymentDetailBAL _paymentDetailBAL;    

        public PaymentDetailController(IPaymentDetailBAL paymentDetailBAL)
        {
            _paymentDetailBAL = paymentDetailBAL;            
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(PaymentDetail entity)
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
                rMsg = _paymentDetailBAL.Create(entity);
            }
            else
            {
                resultMessage = MessageConstants.RecordupdateSuccessfully;
                rMsg = _paymentDetailBAL.Update(entity);
            }

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<PaymentDetailResponse> paymentDetails = _paymentDetailBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, paymentDetails, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int paymentId)
        {
            PaymentDetailResponse paymentDetail = _paymentDetailBAL.GetById(paymentId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, paymentDetail, MessageType.Success.GetStringValue()));
        }
    }
}
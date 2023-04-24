using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/PaymentType")]
    public class PaymentTypeController : BaseAPIController
    {            
        private readonly IPaymentTypeBAL _paymentTypeBAL;    
        private readonly ILogger<PaymentTypeController> _logger;
        
        public PaymentTypeController(IPaymentTypeBAL paymentTypeBAL, ILogger<PaymentTypeController> logger)
        {
            _paymentTypeBAL = paymentTypeBAL;
            _logger = logger;
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(PaymentType entity)
        {
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage;

            if (entity.Id == 0)       
            {
                resultMessage = MessageConstants.RecordInsertSuccessfully;
                rMsg = _paymentTypeBAL.Create(entity);
            }
            else
            {
                resultMessage = MessageConstants.RecordupdateSuccessfully;
                rMsg = _paymentTypeBAL.Update(entity);
            }

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpPost, Route("DeleteData")]
        public IActionResult DeleteData(int paymentId)
        {            
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage = MessageConstants.RecordDeleteSuccessfully;
            rMsg = _paymentTypeBAL.Delete(paymentId);
                   
            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            
            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<PaymentType> paymentTypes = _paymentTypeBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, paymentTypes, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int paymentId)
        {
            PaymentType paymentType = _paymentTypeBAL.GetById(paymentId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, paymentType, MessageType.Success.GetStringValue()));
        }
    }
}
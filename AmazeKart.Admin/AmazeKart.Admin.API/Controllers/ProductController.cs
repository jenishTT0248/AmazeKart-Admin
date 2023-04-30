using AmazeKart.Admin.API.Helpers;
using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using AmazeKart.Admin.Core.ViewModel.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/Product")]
    public class ProductController : BaseAPIController
    {
        private readonly IProductBAL _productBAL;
        public ProductController(IProductBAL productBAL)
        {
            _productBAL = productBAL;
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(Product entity)
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
                rMsg = _productBAL.Create(entity);
            }
            else
            {
                resultMessage = MessageConstants.RecordupdateSuccessfully;
                rMsg = _productBAL.Update(entity);
            }

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpPost, Route("DeleteData")]
        public IActionResult DeleteData(int productId)
        {
            if (productId == 0)
            {
                ResultMessage notFoundMessage = ResultMessage.NotFound;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, notFoundMessage.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage = MessageConstants.RecordDeleteSuccessfully;
            rMsg = _productBAL.Delete(productId);

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));

            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<ProductResponse> products = _productBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, products, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int productId)
        {
            if (productId == 0)
            {
                ResultMessage notFoundMessage = ResultMessage.NotFound;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, notFoundMessage.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            ProductResponse product = _productBAL.GetById(productId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, product, MessageType.Success.GetStringValue()));
        }
    }
}
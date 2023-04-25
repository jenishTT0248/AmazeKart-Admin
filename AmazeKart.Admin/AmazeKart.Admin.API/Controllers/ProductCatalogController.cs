using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using AmazeKart.Admin.Infrastructure.Bal;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/ProductCatalog")]
    public class ProductCatalogController : BaseAPIController
    {
        private readonly ILogger<ProductCatalogController> _logger;
        private readonly IProductCatalogBAL _productCatalogBAL;
        public ProductCatalogController(ILogger<ProductCatalogController> logger, IProductCatalogBAL productCatalogBAL)
        {
            _logger = logger;
            _productCatalogBAL = productCatalogBAL;
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(ProductCatalog entity)
        {
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage;

            if (entity.ProductId == 0)
            {
                resultMessage = MessageConstants.RecordInsertSuccessfully;
                rMsg = _productCatalogBAL.Create(entity);
            }
            else
            {
                resultMessage = MessageConstants.RecordupdateSuccessfully;
                rMsg = _productCatalogBAL.Update(entity);
            }

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpPost, Route("DeleteData")]
        public IActionResult DeleteData(ProductCatalog entity)
        {
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage = MessageConstants.RecordDeleteSuccessfully;
            rMsg = _productCatalogBAL.Delete(entity);

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));

            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<ProductCatalog> productCatalogs = _productCatalogBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, productCatalogs, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int categoryId)
        {
            ProductCatalog productCatalog = _productCatalogBAL.GetById(categoryId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, productCatalog, MessageType.Success.GetStringValue()));
        }
    }
}

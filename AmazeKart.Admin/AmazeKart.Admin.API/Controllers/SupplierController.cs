using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using AmazeKart.Admin.Infrastructure.Bal;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/Supplier")]
    public class SupplierController : BaseAPIController
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly ISupplierBAL _supplierBAL;

        public SupplierController(ISupplierBAL supplierBAL, ILogger<SupplierController> logger)
        {
            _supplierBAL = supplierBAL;
            _logger = logger;
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(Supplier entity)
        {
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage;


            if (entity.SupplierId == 0)
            {
                resultMessage = MessageConstants.RecordInsertSuccessfully;
                rMsg = _supplierBAL.Create(entity);
            }
            else
            {
                resultMessage = MessageConstants.RecordupdateSuccessfully;
                rMsg = _supplierBAL.Update(entity);
            }

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpPost, Route("DeleteData")]
        public IActionResult DeleteData(int supplierId)
        {
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage = MessageConstants.RecordDeleteSuccessfully;
            rMsg = _supplierBAL.Delete(supplierId);

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));

            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Supplier> categories = _supplierBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, categories, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int categoryId)
        {
            Supplier category = _supplierBAL.GetById(categoryId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, category, MessageType.Success.GetStringValue()));
        }

    }
}

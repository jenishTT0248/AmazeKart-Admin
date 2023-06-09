﻿using AmazeKart.Admin.API.Helpers;
using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/Supplier")]
    public class SupplierController : BaseAPIController
    {        
        private readonly ISupplierBAL _supplierBAL;

        public SupplierController(ISupplierBAL supplierBAL)
        {
            _supplierBAL = supplierBAL;            
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(Supplier entity)
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

        [HttpGet, Route("DeleteData")]
        public IActionResult DeleteData(int supplierId)
        {
            if (supplierId <= 0)
            {
                ResultMessage notFoundMessage = ResultMessage.NotFound;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, notFoundMessage.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

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
            List<Supplier> suppliers = _supplierBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, suppliers, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int supplierId)
        {
            if (supplierId <= 0)
            {
                ResultMessage notFoundMessage = ResultMessage.NotFound;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, notFoundMessage.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            Supplier supplier = _supplierBAL.GetById(supplierId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, supplier, MessageType.Success.GetStringValue()));
        }
    }
}
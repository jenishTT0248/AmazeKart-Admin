using AmazeKart.Admin.API.Helpers;
using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IBal;
using AmazeKart.Admin.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/Category")]
    public class CategoryController : BaseAPIController
    {
        private readonly ICategoryBAL _categoryBAL;
        public CategoryController(ICategoryBAL categoryBAL)
        {
            _categoryBAL = categoryBAL;
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(Category entity)
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
                rMsg = _categoryBAL.Create(entity);
            }
            else
            {
                resultMessage = MessageConstants.RecordupdateSuccessfully;
                rMsg = _categoryBAL.Update(entity);
            }

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpPost, Route("DeleteData")]
        public IActionResult DeleteData(int categoryId)
        {
            if(categoryId <= 0)
            {
                ResultMessage notFoundMessage = ResultMessage.NotFound;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, notFoundMessage.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage = MessageConstants.RecordDeleteSuccessfully;
            rMsg = _categoryBAL.Delete(categoryId);

            if (rMsg != ResultMessage.Success)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, rMsg.GetStringValue(), null, MessageType.Warning.GetStringValue()));

            return Ok(new ResponseResult(HttpStatusCode.OK, resultMessage.GetStringValue(), null, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<Category> categories = _categoryBAL.GetAll().ToList();
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, categories, MessageType.Success.GetStringValue()));
        }

        [HttpGet, Route("GetById")]
        public IActionResult GetById(int categoryId)
        {
            if (categoryId <= 0)
            {
                ResultMessage notFoundMessage = ResultMessage.NotFound;
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, notFoundMessage.GetStringValue(), null, MessageType.Warning.GetStringValue()));
            }

            Category category = _categoryBAL.GetById(categoryId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, category, MessageType.Success.GetStringValue()));
        }
    }
}
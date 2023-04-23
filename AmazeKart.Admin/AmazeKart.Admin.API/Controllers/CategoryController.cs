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
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryBAL _categoryBAL;
        public CategoryController(ICategoryBAL categoryBAL, ILogger<CategoryController> logger)
        {
            _categoryBAL = categoryBAL;
            _logger = logger;
        }

        [HttpPost, Route("SaveData")]
        public IActionResult SaveData(Category entity)
        {
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage;

            if (entity.CategoryId == 0)
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
        public IActionResult DeleteData(Category entity)
        {
            ResultMessage rMsg = ResultMessage.RecordNotFound;
            MessageConstants resultMessage = MessageConstants.RecordDeleteSuccessfully;
            rMsg = _categoryBAL.Delete(entity);

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
            Category category = _categoryBAL.GetById(categoryId);
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, category, MessageType.Success.GetStringValue()));
        }
    }
}
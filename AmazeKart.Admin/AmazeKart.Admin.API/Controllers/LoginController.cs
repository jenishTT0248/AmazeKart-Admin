using AmazeKart.Admin.API.Helpers;
using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace AmazeKart.Admin.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IAdminUserService _adminUserService;
        private readonly IConfiguration _configuration;

        public LoginController(IAdminUserService adminUserService, IConfiguration configuration)
        {
            _adminUserService = adminUserService;
            _configuration = configuration;
        }

        [HttpPost, Route("ValidateUser")]    
        public IActionResult ValidateUser([FromBody]AdminUser user)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, ModelState.GetInvalidModelStateErrors(), null, MessageType.Warning.GetStringValue()));
            }

            var adminUser = _adminUserService.ValidateAdminUser(user.EmailId, user.Password);

            if (adminUser == null)
                return Ok(new ResponseResult(HttpStatusCode.BadRequest, string.Empty, null, MessageType.Warning.GetStringValue()));

            var data = new
            {
                accessToken = "Basic " + _configuration.GetValue<string>("APIToken"),
                userDetails = new
                {
                    FirstName = adminUser.FirstName,
                    LastName = adminUser.LastName,
                }
            };
            return Ok(new ResponseResult(HttpStatusCode.OK, string.Empty, data, MessageType.Success.GetStringValue()));
        }
    }
}

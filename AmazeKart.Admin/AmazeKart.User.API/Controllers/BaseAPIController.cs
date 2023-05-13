using AmazeKart.User.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AmazeKart.User.API.Controllers
{
    [FixedTokenAuthorizeAttribute]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
    }
}
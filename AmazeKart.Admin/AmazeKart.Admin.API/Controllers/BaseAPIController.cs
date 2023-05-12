using AmazeKart.Admin.API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AmazeKart.Admin.API.Controllers
{
    [FixedTokenAuthorizeAttribute]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
    }
}
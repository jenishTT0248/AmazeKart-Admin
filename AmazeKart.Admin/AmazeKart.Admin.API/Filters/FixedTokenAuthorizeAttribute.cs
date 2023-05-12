using AmazeKart.Admin.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AmazeKart.Admin.API.Filters
{
    public class FixedTokenAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authToken = GetAuthToken(context.HttpContext);

            if (string.IsNullOrWhiteSpace(authToken))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

            if (string.IsNullOrWhiteSpace(authToken) || authToken.Replace("Basic ", "") != EncryptDecrypt.AES_Decrypt(configuration.GetValue<string>("APIToken")))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        private string GetAuthToken(HttpContext httpContext)
        {
            string authToken = null;

            if (httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                authToken = httpContext.Request.Headers["Authorization"];
            }

            if (string.IsNullOrWhiteSpace(authToken) && httpContext.Request.Query.ContainsKey("Authorization"))
            {
                authToken = httpContext.Request.Query["Authorization"];
            }

            return authToken;
        }
    }    
}

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace AmazeKart.Admin.API.Helpers
{
    public static class CommonHelper
    {
        public static string GetInvalidModelStateErrors(this ModelStateDictionary modelStateDict)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ModelStateEntry modelState in modelStateDict.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    sb.AppendLine(error.ErrorMessage);
                }
            }
            return sb.ToString();
        }
    }
}
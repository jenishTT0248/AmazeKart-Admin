using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.ObjectModel;

namespace AmazeKart.Admin.Core.IServices
{
    public interface IAdminUserService
    {
        AdminUser ValidateAdminUser(string emailId, string password);
    }
}

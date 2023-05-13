using AmazeKart.Admin.Core.Enums;
using AmazeKart.Admin.Core.IRepositories;
using AmazeKart.Admin.Core.IServices;
using AmazeKart.Admin.Core.ObjectModel;
using AutoMapper;

namespace AmazeKart.Admin.Infrastructure.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdminUserRepository _adminUserRepository;
        private readonly IMapper _mapper;
        public AdminUserService(IAdminUserRepository adminUserRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _adminUserRepository = adminUserRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public AdminUser ValidateAdminUser(string emailId, string password)
        {
            return _adminUserRepository.FindOne(x => x.EmailId == emailId && x.PasswordHash == password && x.Active);
        }

    }
}
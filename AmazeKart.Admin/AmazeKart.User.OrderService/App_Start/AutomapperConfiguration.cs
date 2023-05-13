using AmazeKart.User.OrderService.DataContract;
using AutoMapper;

namespace AmazeKart.Admin.API.App_Start
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Orders, Core.ObjectModel.Order>().ReverseMap(); 
        }
    }
}
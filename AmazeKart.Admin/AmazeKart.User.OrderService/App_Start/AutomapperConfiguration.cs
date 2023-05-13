using AmazeKart.User.Core.ObjectModel;
using AmazeKart.User.OrderService.DataContract;
using AutoMapper;

namespace AmazeKart.User.API.App_Start
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<Orders, Order>().ReverseMap(); 
        }
    }
}
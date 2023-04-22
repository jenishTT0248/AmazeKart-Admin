using ViewModel = AmazeKart.Admin.Core.ViewModel;
using  ObjectModel= AmazeKart.Admin.Core.ObjectModel;
using AutoMapper;

namespace AmazeKart.Admin.API.App_Start
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<ViewModel.PaymentType, ObjectModel.PaymentType>();
            CreateMap<ObjectModel.PaymentType, ViewModel.PaymentType>();
        }
    }
}
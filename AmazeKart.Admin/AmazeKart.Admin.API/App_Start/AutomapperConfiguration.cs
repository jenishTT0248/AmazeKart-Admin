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

            CreateMap<ViewModel.Category, ObjectModel.Category>();
            CreateMap<ObjectModel.Category, ViewModel.Category>();

            CreateMap<ViewModel.Customer, ObjectModel.Customer>();
            CreateMap<ObjectModel.Customer, ViewModel.Customer>();

            CreateMap<ViewModel.Order, ObjectModel.Order>();
            CreateMap<ObjectModel.Order, ViewModel.Order>();

            CreateMap<ViewModel.OrderDetail, ObjectModel.OrderDetail>();
            CreateMap<ObjectModel.OrderDetail, ViewModel.OrderDetail>();
            CreateMap<ViewModel.Supplier, ObjectModel.Supplier>();
            CreateMap<ObjectModel.Supplier, ViewModel.Supplier>();

        }
    }
}
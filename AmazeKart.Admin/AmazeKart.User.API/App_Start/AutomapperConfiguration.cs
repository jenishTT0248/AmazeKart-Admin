using ViewModel = AmazeKart.User.Core.ViewModel;
using ViewModelResponse = AmazeKart.User.Core.ViewModel.Response;
using ObjectModel = AmazeKart.User.Core.ObjectModel;
using AutoMapper;

namespace AmazeKart.User.API.App_Start
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<ViewModel.PaymentDetail, ObjectModel.PaymentDetail>();
            CreateMap<ObjectModel.PaymentDetail, ViewModel.PaymentDetail>();

            CreateMap<ObjectModel.PaymentDetail, ViewModelResponse.PaymentDetailResponse>();

            CreateMap<ViewModel.Category, ObjectModel.Category>();
            CreateMap<ObjectModel.Category, ViewModel.Category>();

            CreateMap<ViewModel.Customer, ObjectModel.Customer>();
            CreateMap<ObjectModel.Customer, ViewModel.Customer>();

            CreateMap<ViewModel.Order, ObjectModel.Order>();
            CreateMap<ObjectModel.Order, ViewModel.Order>();

            CreateMap<ObjectModel.Order, ViewModelResponse.OrderResponse>();

            CreateMap<ViewModel.OrderDetail, ObjectModel.OrderDetail>();
            CreateMap<ObjectModel.OrderDetail, ViewModel.OrderDetail>();

            CreateMap<ViewModel.Supplier, ObjectModel.Supplier>();
            CreateMap<ObjectModel.Supplier, ViewModel.Supplier>();

            CreateMap<ViewModel.Product, ObjectModel.Product>();
            CreateMap<ObjectModel.Product, ViewModel.Product>();

            CreateMap<ObjectModel.Product, ViewModelResponse.ProductResponse>();

            CreateMap<ViewModel.ProductDetail, ObjectModel.ProductDetail>();
            CreateMap<ObjectModel.ProductDetail, ViewModel.ProductDetail>();

            CreateMap<ViewModel.ProductCatalog, ObjectModel.ProductCatalog>();
            CreateMap<ObjectModel.ProductCatalog, ViewModel.ProductCatalog>();

            CreateMap<ObjectModel.ProductCatalog, ViewModelResponse.ProductCatalogResponse>();

            CreateMap<ViewModel.Cart, ObjectModel.Cart>();
            CreateMap<ObjectModel.Cart, ViewModel.Cart>();

            CreateMap<ObjectModel.Cart, ViewModelResponse.CartResponse>();

            CreateMap<ViewModel.Size, ObjectModel.Size>();
            CreateMap<ObjectModel.Size, ViewModel.Size>();

            CreateMap<ViewModel.Color, ObjectModel.Color>();
            CreateMap<ObjectModel.Color, ViewModel.Color>();
        }
    }
}
using AutoMapper;
using Test.Entities;
using Test.Models;

namespace Test.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<BuyOrder, BuyOrderModel>().ForMember(d => d.BuyOrderDetails, opt => opt.MapFrom(t=>t.BuyOrderDetails)).ReverseMap();
            CreateMap<BuyOrderDetail, BuyOrderDetailModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ForMember(d => d.OrderDetails, opt => opt.MapFrom(t => t.OrderDetails)).ReverseMap();
            CreateMap<OrderDetail, OrderDetailModel>().ReverseMap();
        }
    }
}

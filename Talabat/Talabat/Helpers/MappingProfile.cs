using AutoMapper;
using DAL.Entities;
using Talabat.API.Helpers;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Services;
using Talabat.DAL.Entities;
using Talabat.DAL.Entities.Order;
using Talabat.DTO;

namespace Talabat.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.ProductCategory, p => p.MapFrom(s => s.ProductCategory.Name))
                .ForMember(p => p.ProductType, p => p.MapFrom(s => s.ProductType.Name))
                .ForMember(p => p.PictureUrl, p => p.MapFrom<ProductPictureUrlResolver>())
                .ForMember(p => p.comments, p => p.MapFrom(s => s.comments));
            CreateMap<DAL.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<AddressDto, DAL.Entities.Order.Address>();
            CreateMap<Product, ProdsForAllProdsDTO>()
                .ForMember(p => p.ProductCategory, p => p.MapFrom(s => s.ProductCategory.Name))
                .ForMember(p => p.ProductType, p => p.MapFrom(s => s.ProductType.Name))
                .ForMember(p => p.PictureUrl, p => p.MapFrom<ProductPictureUrlResolverforallprods>());
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<Comment, CommentDTO>();
            CreateMap<Comment, CommentsSectionDTO>();
            CreateMap<Order, OrderToReturnDto>()

             .ForMember(d => d.DeliveryMethod, O => O.MapFrom(S => S.DeliveryMethod.ShortName))
             .ForMember(d => d.DeliveryCost, O => O.MapFrom(S => S.DeliveryMethod.Cost));
         
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, O => O.MapFrom(S => S.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, O => O.MapFrom(S => S.ItemOrdered.ProductItemName))
                .ForMember(d => d.PictureUrl, O => O.MapFrom(S => S.ItemOrdered.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());


        }
    }
}

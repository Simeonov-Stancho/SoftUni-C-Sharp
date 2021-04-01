using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserDto, User>();

            this.CreateMap<ProductDto, Product>();

            this.CreateMap<CategoryDto, Category>();

            this.CreateMap<CategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ProductInRangeDto>()
                .ForMember(p=>p.Buyer, y=>y.MapFrom(s=>s.Buyer.FirstName + " " + s.Buyer.LastName));
        }
    }
}

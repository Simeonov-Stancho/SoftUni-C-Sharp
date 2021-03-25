using AutoMapper;
using ProductShop.DTOs;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModelDto, User>();

            this.CreateMap<ProductInputModelDto, Product>();

            this.CreateMap<CategoryInputModelDto, Category>();

            this.CreateMap<CategoryProductInputModelDto, CategoryProduct>();

            this.CreateMap<Product, ProductsInRangeDto>()
                .ForMember(x => x.FullName, y=>y.MapFrom(s=>s.Seller.FirstName + " " + s.Seller.LastName));
        }
    }
}

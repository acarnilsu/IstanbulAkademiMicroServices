using AkademiECommerce.Services.Catalog.Dtos;
using AkademiECommerce.Services.Catalog.Models;
using AutoMapper;

namespace AkademiECommerce.Services.Catalog.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
        }
    }
}

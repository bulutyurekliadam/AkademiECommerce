using AkademiECommerce.Servives.Catalog.Dtos.CategoryDtos;
using AkademiECommerce.Servives.Catalog.Dtos.ProductDtos;
using AkademiECommerce.Servives.Catalog.Models;
using AutoMapper;

namespace AkademiECommerce.Servives.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>();
            CreateMap<ResultCategoryDto, Category>();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            

        }
            
    }
}

using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>();
            
            //CreateMap<Product, ProductWithCategoryDto>().ForMember(x => x.CreatedDate, mopt =>  mopt.MapFrom( y => y.CreateDate));
            CreateMap<Product, ProductWithCategoryDto>();

        }
    }
}

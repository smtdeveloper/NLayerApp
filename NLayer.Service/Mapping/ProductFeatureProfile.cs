using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping
{
    public class ProductFeatureProfile : Profile
    {
        public ProductFeatureProfile()
        {
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
        }
    }
}

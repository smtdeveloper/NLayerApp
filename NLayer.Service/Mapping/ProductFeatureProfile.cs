using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class ProductFeatureProfile : Profile
    {
        public ProductFeatureProfile()
        {
            CreateMap<ProductFeature , ProductFeatureDto>().ReverseMap();
        }
    }
}

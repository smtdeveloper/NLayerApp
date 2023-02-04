using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.GenericDTO;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategroryService
    {
        private readonly ICategoryRespository _categoryRespository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRespository categoryRespository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRespository = categoryRespository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProducts(int categoryId)
        {

            var products = await _categoryRespository.GetCategoryByIdWithProductsAsyns(categoryId);

            var productsDto = _mapper.Map<CategoryWithProductsDto>(products);
            return CustomResponseDto<CategoryWithProductsDto>.Success(200, productsDto);

        }

        public async Task<CustomResponseDto<List<CategoryWithProductsDto>>> GetCategoryWithProducts()
        {
            var products = await _categoryRespository.GetCategoryWithProducts();

            var productsDto = _mapper.Map<List<CategoryWithProductsDto>>(products);
            return CustomResponseDto<List<CategoryWithProductsDto>>.Success(200, productsDto);

        }
    }
}

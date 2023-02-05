using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.GenericDTO;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

   
    public class CategoryController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategroryService _categroryService;

        public CategoryController(ICategroryService categroryService, IMapper mapper)
        {
            _categroryService = categroryService;
            _mapper = mapper;
        }


        [HttpGet("GetCategoryByIdWithProducts")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _categroryService.GetCategoryByIdWithProducts(categoryId));
        }

        [HttpGet("GetCategoryWithProducts")]
        public async Task<IActionResult> GetCategoryWithProducts()
        {
            return CreateActionResult(await _categroryService.GetCategoryWithProducts());
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var Categories = await _categroryService.GetAllAsync();
            var CategoryDtos = _mapper.Map<List<CategoryDto>>(Categories).ToList();

            //return Ok(CategoryDtos);
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, CategoryDtos));        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categroryService.GetByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDto));

        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var entity = _mapper.Map<Category>(categoryDto);

            var category = await _categroryService.AddAsync(entity);

            var newDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, newDto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            var entity = _mapper.Map<Category>(categoryDto);
            await _categroryService.UpdateAsync(entity);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var deletedCategory = await _categroryService.GetByIdAsync(id);

            if (deletedCategory == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Category not found! "));
            }

            await _categroryService.RemoveAsync(deletedCategory);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }


    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.GenericDTO;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductController(IService<Product> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products).ToList();

            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));

        }

        // www.mysite.com/api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var entity = _mapper.Map<Product>(productDto);

            var product = await _service.AddAsync(entity);

            var newDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, newDto));

        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var entity = _mapper.Map<Product>(productUpdateDto);
            await _service.UpdateAsync(entity);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var deletedProduct = await _service.GetByIdAsync(id);

            if (deletedProduct == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Product not found! "));
            }

            await _service.RemoveAsync(deletedProduct);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }


    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.GenericDTO;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Exceptions;

namespace NLayer.API.Controllers
{


    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {

            _mapper = mapper;
            _productService = productService;
        }


        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            var productDtos = _mapper.Map<List<ProductDto>>(products).ToList();

            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));

        }


        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        // www.mysite.com/api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));

        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var entity = _mapper.Map<Product>(productDto);

            var product = await _productService.AddAsync(entity);

            var newDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, newDto));
        }

        [HttpPost("saveall")]
        public async Task<IActionResult> SaveAll(IEnumerable<ProductDto> productDtos)
        {

            var newEntities = _mapper.Map<IEnumerable<Product>>(productDtos);
            await _productService.AddRangeAsync(newEntities);
            var newDtos = _mapper.Map<IEnumerable<Product>>(newEntities);

            return CreateActionResult(CustomResponseDto<IEnumerable<Product>>.Success(201, newDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            var entity = _mapper.Map<Product>(productDto);
            await _productService.UpdateAsync(entity);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpDelete("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var deletedProduct = await _productService.GetByIdAsync(id);

            // gerek kalmadı ! . Service katmanında tanımladık
            //if (deletedProduct == null)
            //{
            //    return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Product not found! "));
            //}

            await _productService.RemoveAsync(deletedProduct);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpDelete("RemoveAll")]
        public async Task<IActionResult> RemoveAll([FromBody] List<int> ids)
        {

            foreach (var id in ids)
            {
                var deletedProduct = await _productService.GetByIdAsync(id);
                await _productService.RemoveAsync(deletedProduct);
            }

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [HttpGet("any")]
        public async Task<IActionResult> Any(int id)
        {
            var entity = await _productService.AnyAsync(x => x.Id == id);
            return CreateActionResult(CustomResponseDto<bool>.Success(200,entity));

        }


    }
}

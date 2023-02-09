using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Services;
using NLayer.Web.Filters;

namespace NLayer.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategroryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategroryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _categoryService.GetCategoryWithProducts();
            return View(values.Data);
        }


        [HttpGet]
        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
                return RedirectToAction(nameof(Index));
            }

            return View();

        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        public async Task<IActionResult> Update(int id)
        {
            var value = await _categoryService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(value));

        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {

                await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryDto));
                return RedirectToAction(nameof(Index));
            }

            return View(categoryDto);

        }

        public async Task<IActionResult> Remove(int id)
        {
            var product = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(product);

            return RedirectToAction(nameof(Index));
        }



    }
}

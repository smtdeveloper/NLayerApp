using NLayer.Core.DTOs;
using NLayer.Core.DTOs.GenericDTO;
using NLayer.Core.Models;

namespace NLayer.Core.Services
{
    public interface ICategroryService : IService<Category>
    {
        Task<CustomResponseDto<List<CategoryWithProductsDto>>> GetCategoryWithProducts();
        Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProducts(int categoryId);
    }
}

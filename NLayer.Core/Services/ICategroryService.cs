using NLayer.Core.DTOs.GenericDTO;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategroryService : IService<Category>
    {
        Task<CustomResponseDto<List<CategoryWithProductsDto>>> GetCategoryWithProducts();
        Task<CustomResponseDto<CategoryWithProductsDto>> GetCategoryByIdWithProducts(int categoryId);
    }
}

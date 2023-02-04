using NLayer.Core.DTOs;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRespository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoryWithProducts();
        Task<Category> GetCategoryByIdWithProductsAsyns(int categoryId);

    }
}

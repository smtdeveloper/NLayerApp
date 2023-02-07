using NLayer.Core.Models;

namespace NLayer.Core.Repositories
{
    public interface ICategoryRespository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoryWithProducts();
        Task<Category> GetCategoryByIdWithProductsAsyns(int categoryId);

    }
}

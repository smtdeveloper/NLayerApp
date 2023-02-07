using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRespository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdWithProductsAsyns(int categoryId)
        {
            return await _context.Categories.Include(x => x.Products).Where(y => y.Id == categoryId).SingleOrDefaultAsync();
        }

        public async Task<List<Category>> GetCategoryWithProducts()
        {
            return await _context.Categories.Include(x => x.Products).ToListAsync();
        }
    }
}

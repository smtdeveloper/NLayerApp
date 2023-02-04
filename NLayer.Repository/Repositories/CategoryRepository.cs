using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           return await _context.Categories.Include( x => x.Products).ToListAsync();
        }
    }
}

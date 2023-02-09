using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        // örnek Seed Data 
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Red Dead 2", Price = 1000, Stock = 20, CreatedDate = DateTime.Now, Declaration ="Test acıklama" ,Image = "1.jpg" , IsDelete = false   },
                new Product { Id = 2, CategoryId = 1, Name = "God Of War", Price = 3500, Stock = 8, CreatedDate = DateTime.Now, Declaration = "Test acıklama", Image = "2.jpg", IsDelete = false },
                new Product { Id = 3, CategoryId = 2, Name = "Last of part 1", Price = 1550, Stock = 25, CreatedDate = DateTime.Now, Declaration = "Test acıklama", Image = "3.jpg", IsDelete = false },
                new Product { Id = 4, CategoryId = 3, Name = "Last of part 2", Price = 5400, Stock = 36, CreatedDate = DateTime.Now, Declaration = "Test acıklama", Image = "4.jpg", IsDelete = false }
                );
        }
    }
}

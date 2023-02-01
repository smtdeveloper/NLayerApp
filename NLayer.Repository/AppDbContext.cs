using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductFeature> ProductFeatures{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //hepsini buluyor ve uyguluyor
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            ////tek tek yazıp uyguluyor
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductFeatureConfigyration());

            // örnek Seed Data 
            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature {Id =1 ,Color = "Kırmızı" ,Height = 100 , Width = 180 ,ProductId = 1 },
                new ProductFeature {Id =2 ,Color = "Mavi" ,Height = 80 , Width = 120 ,ProductId = 2 }
                );


            base.OnModelCreating(modelBuilder);
        }


    }
}

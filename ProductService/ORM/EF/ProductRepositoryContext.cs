using Microsoft.EntityFrameworkCore;
using ProductService.ORM.EF.Model;
using ProductService.ORM.EF.ReposConfiguration;

namespace ProductService.ORM.EF
{
    public class ProductRepositoryContext : DbContext
    {
        public ProductRepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductReposConfiguration());
        }

        public DbSet<Product> Products { get; set; }



    }
}

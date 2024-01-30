using Microsoft.EntityFrameworkCore;
using ProductServiceNamespace.ORM.EF.Model;
using ProductServiceNamespace.ORM.EF.ReposConfiguration;

namespace ProductServiceNamespace.ORM.EF
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

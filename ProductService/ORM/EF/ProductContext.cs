using Microsoft.EntityFrameworkCore;
using ProductServiceNamespace.ORM.EF.Model;
using ProductServiceNamespace.ORM.EF.ReposConfiguration;

namespace ProductServiceNamespace.ORM.EF
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCFFA3FB564");

                entity.ToTable("Order");

                entity.Property(e => e.OrderId).ValueGeneratedNever();
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__CustomerI__09A971A2");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__OrderIte__08D097A3535DCB79");

                entity.ToTable("OrderItem");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__Order__0C85DE4D");

                entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__Produ__0D7A0286");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => e.PriceId).HasName("PK__Price__49575BAF4066059C");

                entity.ToTable("Price");

                entity.Property(e => e.PriceId).ValueGeneratedNever();
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.PriceValue).HasColumnType("decimal(12, 2)");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Product).WithMany(p => p.Prices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Price__UpdatedDa__06CD04F7");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();
                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.UpdatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
            });
            modelBuilder.ApplyConfiguration(new ProductReposConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }


    }
}

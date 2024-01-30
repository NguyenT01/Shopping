using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductServiceNamespace.ORM.EF.Model;

namespace ProductServiceNamespace.ORM.EF.ReposConfiguration
{
    public class ProductReposConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Ca Sa Ba",
                    Description = "Cá thu Nhật hay Cá sa ba hay sa pa, còn biết đến như là cá thu Thái Bình Dương, cá thu Nhật Bản, cá thu lam hoặc cá thu bống"
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Bap cai",
                    Description = "Bắp cải hay cải bắp hay cải nồi là một loại rau chủ lực trong họ Cải, phát sinh từ vùng Địa Trung Hải. Nó là cây thân thảo, sống hai năm,"
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Name = "Khoai tay",
                    Description = "Khoai tây, thuộc họ Cà. Khoai tây là loài cây nông nghiệp ngắn ngày, trồng lấy củ chứa tinh bột. Chúng là loại cây trồng lấy củ rộng rãi nhất thế giới và là loại"
                }
                );
        }

    }
}

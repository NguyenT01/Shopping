using MasterDataService.ORM.EF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterDataService.ORM.EF.ReposConfiguration
{
    public class CustomerReposConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    CustomerId = Guid.NewGuid(),
                    FirstName = "Alexa",
                    LastName = "Otofun",
                    Email = "alexo@gmail.com",
                    Address = "123 King Street, UK"
                },
                new Customer
                {
                    CustomerId = Guid.NewGuid(),
                    FirstName = "Maxima",
                    LastName = "Pokemon",
                    Email = "poke222@gmail.com",
                    Address = "222 West Street, EU"
                },
                new Customer
                {
                    CustomerId = Guid.NewGuid(),
                    FirstName = "Sandro",
                    LastName = "Picheno",
                    Email = "sans1@gmail.com",
                    Address = "872 Leed Street, AU"
                });
        }
    }
}

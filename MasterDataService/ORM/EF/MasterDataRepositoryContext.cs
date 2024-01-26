using MasterDataService.ORM.EF.Model;
using MasterDataService.ORM.EF.ReposConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MasterDataService.ORM.EF;

public class MasterDataRepositoryContext : DbContext
{
    public MasterDataRepositoryContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerReposConfiguration());
    }

    public DbSet<Customer>? Customer { get; set; }
}

namespace UCondoAccountTree.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;
using UCondoAccountTree.Domain.AggregatesModels.Accounts;
using UCondoAccountTree.Domain.AggregatesModels.AccountTypes;

public class UCondoAccountTreeContext : DbContext
{
    public UCondoAccountTreeContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<AccountsRelations> AccountRelations { get; set; }
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UCondoAccountTreeContext).Assembly);
    }
}

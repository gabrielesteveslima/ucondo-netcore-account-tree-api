namespace UCondoAccountTree.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeedWork;

public class UCondoContextFactory : IDesignTimeDbContextFactory<UCondoAccountTreeContext>
{
    public UCondoAccountTreeContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<UCondoAccountTreeContext> optionsBuilder =
            new();
        optionsBuilder.UseSqlServer(
            "User Id=sa;Password=admin@123;Server=localhost;Database=UCondoAccountTree");
        optionsBuilder.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

        return new UCondoAccountTreeContext(optionsBuilder.Options);
    }
}

namespace UCondoAccountTree.Infrastructure.Domain.Repository.MappingDb;

using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCondoAccountTree.Domain.AggregatesModels.AccountTypes;

public class AccountTypeEntityTypeConfiguration : IEntityTypeConfiguration<AccountType>
{
    public void Configure(EntityTypeBuilder<AccountType> builder)
    {
        builder
            .ToTable(TableNames.AccountType, SchemaName.UCondoAccountTree)
            .HasKey(x => x.AccountTypeId);

        builder.Property(x => x.Name);
        builder.Ignore(x => x.AccountId);

        builder.HasMany(x => x.AccountsRef)
            .WithOne(x => x.AccountTypeRef)
            .HasForeignKey(x => x.AccountTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

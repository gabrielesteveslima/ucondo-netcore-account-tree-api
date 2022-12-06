namespace UCondoAccountTree.Infrastructure.Domain.Repository.MappingDb;

using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UCondoAccountTree.Domain.AggregatesModels.Accounts;

public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .ToTable(TableNames.Account, SchemaName.UCondoAccountTree)
            .HasKey(x => x.AccountId);

        builder.Property(x => x.Name);
        builder.Property(x => x.AcceptBilling);

        builder.OwnsOne(x => x.AccountCode)
            .Property(x => x.Value)
            .HasColumnName("AccountCode")
            .IsRequired();
        
        builder.HasOne(x => x.AccountTypeRef)
            .WithMany(x => x.AccountsRef)
            .HasForeignKey(x => x.AccountTypeId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.OwnsMany(o => o.AccountsRelations, navigationBuilder =>
        {
            navigationBuilder.ToTable("AccountRelations", SchemaName.UCondoAccountTree);
            navigationBuilder.HasKey("ParentAccountId", "ChildAccountId");
            navigationBuilder.WithOwner().HasForeignKey("ParentAccountId");
        });
    }
}

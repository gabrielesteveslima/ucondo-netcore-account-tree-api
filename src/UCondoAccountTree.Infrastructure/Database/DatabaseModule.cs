namespace UCondoAccountTree.Infrastructure.Database;

using Application.Configuration;
using Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeedWork;
using UCondoAccountTree.Domain.AggregatesModels.Accounts;
using UCondoAccountTree.Domain.AggregatesModels.AccountTypes;

public class DatabaseModule : Module
{
    private readonly string _databaseConnectionString;

    public DatabaseModule(string databaseConnectionString)
    {
        _databaseConnectionString = databaseConnectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ConnectionsFactory>()
            .As<IConnectionFactory>()
            .WithParameter("databaseConnectionString", _databaseConnectionString)
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterType<AccountRepository>()
            .As<IAccountRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<AccountTypeRepository>()
            .As<IAccountTypeRepository>()
            .InstancePerLifetimeScope();

        builder
            .Register(_ =>
            {
                DbContextOptionsBuilder<UCondoAccountTreeContext> dbContextOptionsBuilder = new();
                dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                dbContextOptionsBuilder
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                return new UCondoAccountTreeContext(dbContextOptionsBuilder.Options);
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}

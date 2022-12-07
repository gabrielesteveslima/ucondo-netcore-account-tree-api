﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UCondoAccountTree.Infrastructure.Database;

#nullable disable

namespace UCondoAccountTree.Infrastructure.Migrations
{
    [DbContext(typeof(UCondoAccountTreeContext))]
    partial class UCondoAccountTreeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UCondoAccountTree.Domain.AggregatesModels.Accounts.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AcceptBilling")
                        .HasColumnType("bit");

                    b.Property<Guid>("AccountTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("AccountTypeId");

                    b.ToTable("Accounts", "dbo");
                });

            modelBuilder.Entity("UCondoAccountTree.Domain.AggregatesModels.AccountTypes.AccountType", b =>
                {
                    b.Property<Guid>("AccountTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountTypeId");

                    b.ToTable("AccountTypes", "dbo");

                    b.HasData(
                        new
                        {
                            AccountTypeId = new Guid("476e1eb6-40fb-4276-b58a-f4985f8dec56"),
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Receitas"
                        },
                        new
                        {
                            AccountTypeId = new Guid("7c1f24fb-985b-4a85-8283-64590034cb7b"),
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Taxas Condominiais"
                        },
                        new
                        {
                            AccountTypeId = new Guid("4ce68b54-fa8d-47e1-af0f-4bc20ef71f60"),
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Multas"
                        },
                        new
                        {
                            AccountTypeId = new Guid("bad3d653-5187-4199-80c0-fda7d4d82c7f"),
                            CreateAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Despesas"
                        });
                });

            modelBuilder.Entity("UCondoAccountTree.Domain.AggregatesModels.Accounts.Account", b =>
                {
                    b.HasOne("UCondoAccountTree.Domain.AggregatesModels.AccountTypes.AccountType", "AccountTypeRef")
                        .WithMany("AccountsRef")
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("UCondoAccountTree.Domain.AggregatesModels.Accounts.AccountCode", "AccountCode", b1 =>
                        {
                            b1.Property<Guid>("AccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AccountCode");

                            b1.HasKey("AccountId");

                            b1.ToTable("Accounts", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.OwnsMany("UCondoAccountTree.Domain.AggregatesModels.Accounts.AccountsRelations", "AccountsRelations", b1 =>
                        {
                            b1.Property<Guid>("ParentAccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ChildAccountId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreateAt")
                                .HasColumnType("datetime2");

                            b1.HasKey("ParentAccountId", "ChildAccountId");

                            b1.ToTable("AccountRelations", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("ParentAccountId");
                        });

                    b.Navigation("AccountCode")
                        .IsRequired();

                    b.Navigation("AccountTypeRef");

                    b.Navigation("AccountsRelations");
                });

            modelBuilder.Entity("UCondoAccountTree.Domain.AggregatesModels.AccountTypes.AccountType", b =>
                {
                    b.Navigation("AccountsRef");
                });
#pragma warning restore 612, 618
        }
    }
}

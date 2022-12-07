using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCondoAccountTree.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                schema: "dbo",
                columns: table => new
                {
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "dbo",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcceptBilling = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalSchema: "dbo",
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountRelations",
                schema: "dbo",
                columns: table => new
                {
                    ParentAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChildAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRelations", x => new { x.ParentAccountId, x.ChildAccountId });
                    table.ForeignKey(
                        name: "FK_AccountRelations_Accounts_ParentAccountId",
                        column: x => x.ParentAccountId,
                        principalSchema: "dbo",
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AccountTypes",
                columns: new[] { "AccountTypeId", "CreateAt", "Name" },
                values: new object[,]
                {
                    { new Guid("476e1eb6-40fb-4276-b58a-f4985f8dec56"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Receitas" },
                    { new Guid("4ce68b54-fa8d-47e1-af0f-4bc20ef71f60"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Multas" },
                    { new Guid("7c1f24fb-985b-4a85-8283-64590034cb7b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taxas Condominiais" },
                    { new Guid("bad3d653-5187-4199-80c0-fda7d4d82c7f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Despesas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                schema: "dbo",
                table: "Accounts",
                column: "AccountTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRelations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AccountTypes",
                schema: "dbo");
        }
    }
}

#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineAccounting.Persistence.CompanyMigrations;

/// <inheritdoc />
public partial class InitialCompanyMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "GlAccounts",
            table => new
            {
                Id = table.Column<long>("bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Code = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                Name = table.Column<string>("nvarchar(400)", maxLength: 400, nullable: false),
                Type = table.Column<string>("nvarchar(1)", nullable: false),
                CompanyId = table.Column<long>("bigint", nullable: false),
                CreatedDate = table.Column<DateTime>("datetime2", nullable: false),
                UpdatedDate = table.Column<DateTime>("datetime2", nullable: true),
                IsDeleted = table.Column<bool>("bit", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_GlAccounts", x => x.Id); });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "GlAccounts");
    }
}
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAccounting.Persistence.CompanyMigrations
{
    /// <inheritdoc />
    public partial class Update_GLAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "GlAccounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "GlAccounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

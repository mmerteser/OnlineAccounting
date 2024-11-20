using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAccounting.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update_Company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesOfUsers_AspNetUsers_UserId",
                table: "CompaniesOfUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CompaniesOfUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesOfUsers_AspNetUsers_UserId",
                table: "CompaniesOfUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompaniesOfUsers_AspNetUsers_UserId",
                table: "CompaniesOfUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CompaniesOfUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_CompaniesOfUsers_AspNetUsers_UserId",
                table: "CompaniesOfUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class DextureModelsContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Farmers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Buyers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AgricultureOfficers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AgricultureOfficers");
        }
    }
}

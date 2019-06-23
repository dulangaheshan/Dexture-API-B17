using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class DextureModelsContext8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Lands",
                newName: "Longitude");

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Lands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Lands");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Lands",
                newName: "Location");
        }
    }
}

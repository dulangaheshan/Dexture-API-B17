using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class asas221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Land_Harvest_Harvests_HarvestId",
                table: "Land_Harvest");

            migrationBuilder.DropForeignKey(
                name: "FK_Land_Harvest_Lands_LandId",
                table: "Land_Harvest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Land_Harvest",
                table: "Land_Harvest");

            migrationBuilder.RenameTable(
                name: "Land_Harvest",
                newName: "land_Harvests");

            migrationBuilder.RenameIndex(
                name: "IX_Land_Harvest_LandId",
                table: "land_Harvests",
                newName: "IX_land_Harvests_LandId");

            migrationBuilder.RenameIndex(
                name: "IX_Land_Harvest_HarvestId",
                table: "land_Harvests",
                newName: "IX_land_Harvests_HarvestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_land_Harvests",
                table: "land_Harvests",
                column: "LAnd_Harvest");

            migrationBuilder.AddForeignKey(
                name: "FK_land_Harvests_Harvests_HarvestId",
                table: "land_Harvests",
                column: "HarvestId",
                principalTable: "Harvests",
                principalColumn: "HarvestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_land_Harvests_Lands_LandId",
                table: "land_Harvests",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "LandId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_land_Harvests_Harvests_HarvestId",
                table: "land_Harvests");

            migrationBuilder.DropForeignKey(
                name: "FK_land_Harvests_Lands_LandId",
                table: "land_Harvests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_land_Harvests",
                table: "land_Harvests");

            migrationBuilder.RenameTable(
                name: "land_Harvests",
                newName: "Land_Harvest");

            migrationBuilder.RenameIndex(
                name: "IX_land_Harvests_LandId",
                table: "Land_Harvest",
                newName: "IX_Land_Harvest_LandId");

            migrationBuilder.RenameIndex(
                name: "IX_land_Harvests_HarvestId",
                table: "Land_Harvest",
                newName: "IX_Land_Harvest_HarvestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Land_Harvest",
                table: "Land_Harvest",
                column: "LAnd_Harvest");

            migrationBuilder.AddForeignKey(
                name: "FK_Land_Harvest_Harvests_HarvestId",
                table: "Land_Harvest",
                column: "HarvestId",
                principalTable: "Harvests",
                principalColumn: "HarvestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Land_Harvest_Lands_LandId",
                table: "Land_Harvest",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "LandId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

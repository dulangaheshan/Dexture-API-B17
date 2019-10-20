using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class Dexturemodelscontext4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FutureCultivation_Farmers_FarmerId",
                table: "FutureCultivation");

            migrationBuilder.DropForeignKey(
                name: "FK_Generate_FutureCultivation_CultivationId",
                table: "Generate");

            migrationBuilder.DropForeignKey(
                name: "FK_Generate_Harvest_HarvestId",
                table: "Generate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Harvest",
                table: "Harvest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FutureCultivation",
                table: "FutureCultivation");

            migrationBuilder.RenameTable(
                name: "Harvest",
                newName: "Harvests");

            migrationBuilder.RenameTable(
                name: "FutureCultivation",
                newName: "FutureCultivations");

            migrationBuilder.RenameIndex(
                name: "IX_FutureCultivation_FarmerId",
                table: "FutureCultivations",
                newName: "IX_FutureCultivations_FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Harvests",
                table: "Harvests",
                column: "HarvestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FutureCultivations",
                table: "FutureCultivations",
                column: "CultivationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FutureCultivations_Farmers_FarmerId",
                table: "FutureCultivations",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Generate_FutureCultivations_CultivationId",
                table: "Generate",
                column: "CultivationId",
                principalTable: "FutureCultivations",
                principalColumn: "CultivationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Generate_Harvests_HarvestId",
                table: "Generate",
                column: "HarvestId",
                principalTable: "Harvests",
                principalColumn: "HarvestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FutureCultivations_Farmers_FarmerId",
                table: "FutureCultivations");

            migrationBuilder.DropForeignKey(
                name: "FK_Generate_FutureCultivations_CultivationId",
                table: "Generate");

            migrationBuilder.DropForeignKey(
                name: "FK_Generate_Harvests_HarvestId",
                table: "Generate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Harvests",
                table: "Harvests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FutureCultivations",
                table: "FutureCultivations");

            migrationBuilder.RenameTable(
                name: "Harvests",
                newName: "Harvest");

            migrationBuilder.RenameTable(
                name: "FutureCultivations",
                newName: "FutureCultivation");

            migrationBuilder.RenameIndex(
                name: "IX_FutureCultivations_FarmerId",
                table: "FutureCultivation",
                newName: "IX_FutureCultivation_FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Harvest",
                table: "Harvest",
                column: "HarvestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FutureCultivation",
                table: "FutureCultivation",
                column: "CultivationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FutureCultivation_Farmers_FarmerId",
                table: "FutureCultivation",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Generate_FutureCultivation_CultivationId",
                table: "Generate",
                column: "CultivationId",
                principalTable: "FutureCultivation",
                principalColumn: "CultivationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Generate_Harvest_HarvestId",
                table: "Generate",
                column: "HarvestId",
                principalTable: "Harvest",
                principalColumn: "HarvestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

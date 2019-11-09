using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class Dexturemodelscontext5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Generate_FutureCultivations_CultivationId",
                table: "Generate");

            migrationBuilder.DropForeignKey(
                name: "FK_Generate_Harvests_HarvestId",
                table: "Generate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generate",
                table: "Generate");

            migrationBuilder.RenameTable(
                name: "Generate",
                newName: "Generates");

            migrationBuilder.RenameIndex(
                name: "IX_Generate_HarvestId",
                table: "Generates",
                newName: "IX_Generates_HarvestId");

            migrationBuilder.RenameIndex(
                name: "IX_Generate_CultivationId",
                table: "Generates",
                newName: "IX_Generates_CultivationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generates",
                table: "Generates",
                column: "GenerateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Generates_FutureCultivations_CultivationId",
                table: "Generates",
                column: "CultivationId",
                principalTable: "FutureCultivations",
                principalColumn: "CultivationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Generates_Harvests_HarvestId",
                table: "Generates",
                column: "HarvestId",
                principalTable: "Harvests",
                principalColumn: "HarvestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Generates_FutureCultivations_CultivationId",
                table: "Generates");

            migrationBuilder.DropForeignKey(
                name: "FK_Generates_Harvests_HarvestId",
                table: "Generates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generates",
                table: "Generates");

            migrationBuilder.RenameTable(
                name: "Generates",
                newName: "Generate");

            migrationBuilder.RenameIndex(
                name: "IX_Generates_HarvestId",
                table: "Generate",
                newName: "IX_Generate_HarvestId");

            migrationBuilder.RenameIndex(
                name: "IX_Generates_CultivationId",
                table: "Generate",
                newName: "IX_Generate_CultivationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generate",
                table: "Generate",
                column: "GenerateId");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class DextureModelsContexts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FutureCultivation_Farmers_FarmerId",
                table: "FutureCultivation");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "FutureCultivation",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FutureCultivation_Farmers_FarmerId",
                table: "FutureCultivation",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FutureCultivation_Farmers_FarmerId",
                table: "FutureCultivation");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "FutureCultivation",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FutureCultivation_Farmers_FarmerId",
                table: "FutureCultivation",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "FarmerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

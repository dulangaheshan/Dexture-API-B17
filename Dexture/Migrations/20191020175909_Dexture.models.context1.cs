using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class Dexturemodelscontext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FutureCultivation_Harvest_HarvestId",
                table: "FutureCultivation");

            migrationBuilder.DropIndex(
                name: "IX_FutureCultivation_HarvestId",
                table: "FutureCultivation");

            migrationBuilder.DropColumn(
                name: "HarvestId",
                table: "FutureCultivation");

            migrationBuilder.CreateTable(
                name: "Generate",
                columns: table => new
                {
                    GenerateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HarvestId = table.Column<int>(nullable: true),
                    CultivationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generate", x => x.GenerateId);
                    table.ForeignKey(
                        name: "FK_Generate_FutureCultivation_CultivationId",
                        column: x => x.CultivationId,
                        principalTable: "FutureCultivation",
                        principalColumn: "CultivationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Generate_Harvest_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "Harvest",
                        principalColumn: "HarvestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generate_CultivationId",
                table: "Generate",
                column: "CultivationId");

            migrationBuilder.CreateIndex(
                name: "IX_Generate_HarvestId",
                table: "Generate",
                column: "HarvestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Generate");

            migrationBuilder.AddColumn<int>(
                name: "HarvestId",
                table: "FutureCultivation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FutureCultivation_HarvestId",
                table: "FutureCultivation",
                column: "HarvestId");

            migrationBuilder.AddForeignKey(
                name: "FK_FutureCultivation_Harvest_HarvestId",
                table: "FutureCultivation",
                column: "HarvestId",
                principalTable: "Harvest",
                principalColumn: "HarvestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

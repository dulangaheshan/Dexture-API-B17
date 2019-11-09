using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class Dexturemodelscontext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "predictions",
                columns: table => new
                {
                    PredictionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<double>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    DemandRate = table.Column<double>(nullable: false),
                    FutureCultivationCultivationId = table.Column<int>(nullable: true),
                    HarvestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_predictions", x => x.PredictionID);
                    table.ForeignKey(
                        name: "FK_predictions_FutureCultivation_FutureCultivationCultivationId",
                        column: x => x.FutureCultivationCultivationId,
                        principalTable: "FutureCultivation",
                        principalColumn: "CultivationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_predictions_Harvest_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "Harvest",
                        principalColumn: "HarvestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_predictions_FutureCultivationCultivationId",
                table: "predictions",
                column: "FutureCultivationCultivationId");

            migrationBuilder.CreateIndex(
                name: "IX_predictions_HarvestId",
                table: "predictions",
                column: "HarvestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "predictions");
        }
    }
}

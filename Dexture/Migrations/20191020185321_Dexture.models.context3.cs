using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class Dexturemodelscontext3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "predictions");

            migrationBuilder.CreateTable(
                name: "Prediction",
                columns: table => new
                {
                    LandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Size = table.Column<double>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    FarmerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prediction", x => x.LandId);
                    table.ForeignKey(
                        name: "FK_Prediction_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prediction_FarmerId",
                table: "Prediction",
                column: "FarmerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prediction");

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    LandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FarmerId = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Size = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.LandId);
                    table.ForeignKey(
                        name: "FK_Lands_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "predictions",
                columns: table => new
                {
                    PredictionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: true),
                    DemandRate = table.Column<double>(nullable: false),
                    FutureCultivationCultivationId = table.Column<int>(nullable: true),
                    HarvestId = table.Column<int>(nullable: true),
                    Quantity = table.Column<double>(nullable: false)
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
                name: "IX_Lands_FarmerId",
                table: "Lands",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_predictions_FutureCultivationCultivationId",
                table: "predictions",
                column: "FutureCultivationCultivationId");

            migrationBuilder.CreateIndex(
                name: "IX_predictions_HarvestId",
                table: "predictions",
                column: "HarvestId");
        }
    }
}

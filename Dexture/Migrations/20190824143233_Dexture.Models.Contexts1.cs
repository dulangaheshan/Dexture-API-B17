using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class DextureModelsContexts1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Harvest",
                columns: table => new
                {
                    HarvestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SellingQuantity = table.Column<string>(nullable: true),
                    AllQuantity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvest", x => x.HarvestId);
                });

            migrationBuilder.CreateTable(
                name: "FutureCultivation",
                columns: table => new
                {
                    CultivationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<double>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    FarmerId = table.Column<int>(nullable: true),
                    HarvestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureCultivation", x => x.CultivationId);
                    table.ForeignKey(
                        name: "FK_FutureCultivation_Farmers_FarmerId",
                        column: x => x.FarmerId,
                        principalTable: "Farmers",
                        principalColumn: "FarmerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FutureCultivation_Harvest_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "Harvest",
                        principalColumn: "HarvestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FutureCultivation_FarmerId",
                table: "FutureCultivation",
                column: "FarmerId");

            migrationBuilder.CreateIndex(
                name: "IX_FutureCultivation_HarvestId",
                table: "FutureCultivation",
                column: "HarvestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FutureCultivation");

            migrationBuilder.DropTable(
                name: "Harvest");
        }
    }
}

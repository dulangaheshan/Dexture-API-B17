using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class asas22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Land_Harvest",
                columns: table => new
                {
                    LAnd_Harvest = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HarvestId = table.Column<int>(nullable: true),
                    LandId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Land_Harvest", x => x.LAnd_Harvest);
                    table.ForeignKey(
                        name: "FK_Land_Harvest_Harvests_HarvestId",
                        column: x => x.HarvestId,
                        principalTable: "Harvests",
                        principalColumn: "HarvestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Land_Harvest_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "LandId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Land_Harvest_HarvestId",
                table: "Land_Harvest",
                column: "HarvestId");

            migrationBuilder.CreateIndex(
                name: "IX_Land_Harvest_LandId",
                table: "Land_Harvest",
                column: "LandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Land_Harvest");
        }
    }
}

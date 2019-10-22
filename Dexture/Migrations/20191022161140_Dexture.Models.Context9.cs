using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dexture.Migrations
{
    public partial class DextureModelsContext9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    HarvestID = table.Column<int>(nullable: false),
                    AuctionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.AuctionID);
                    table.ForeignKey(
                        name: "FK_Auctions_Harvests_HarvestID",
                        column: x => x.HarvestID,
                        principalTable: "Harvests",
                        principalColumn: "HarvestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_HarvestID",
                table: "Auctions",
                column: "HarvestID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auctions");
        }
    }
}

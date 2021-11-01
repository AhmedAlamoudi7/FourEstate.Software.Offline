using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourEstate.Data.Migrations
{
    public partial class NewAuction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionAttachments");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.CreateTable(
                name: "AuctionsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOAuction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPieces = table.Column<int>(type: "int", nullable: false),
                    AuctionType = table.Column<int>(type: "int", nullable: false),
                    CourtType = table.Column<int>(type: "int", nullable: false),
                    Stauts = table.Column<int>(type: "int", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionsDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionsDb_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDbAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionDbId = table.Column<int>(type: "int", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDbAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionDbAttachments_AuctionsDb_AuctionDbId",
                        column: x => x.AuctionDbId,
                        principalTable: "AuctionsDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDbAttachments_AuctionDbId",
                table: "AuctionDbAttachments",
                column: "AuctionDbId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionsDb_RealEstateId",
                table: "AuctionsDb",
                column: "RealEstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionDbAttachments");

            migrationBuilder.DropTable(
                name: "AuctionsDb");

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionType = table.Column<int>(type: "int", nullable: false),
                    CourtType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOAuction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfPieces = table.Column<int>(type: "int", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    Stauts = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionAttachments_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionAttachments_AuctionId",
                table: "AuctionAttachments",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_RealEstateId",
                table: "Auctions",
                column: "RealEstateId");
        }
    }
}

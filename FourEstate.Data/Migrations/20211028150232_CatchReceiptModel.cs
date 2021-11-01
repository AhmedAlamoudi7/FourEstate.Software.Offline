using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourEstate.Data.Migrations
{
    public partial class CatchReceiptModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatchReceipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateReceipt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    RentContractId = table.Column<int>(type: "int", nullable: false),
                    ReceiptNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ValueReceipt = table.Column<double>(type: "float", nullable: false),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    statment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatchReceipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatchReceipts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatchReceipts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatchReceipts_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatchReceipts_RentContracts_RentContractId",
                        column: x => x.RentContractId,
                        principalTable: "RentContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatchReceipts_CustomerId",
                table: "CatchReceipts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CatchReceipts_RealEstateId",
                table: "CatchReceipts",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_CatchReceipts_RentContractId",
                table: "CatchReceipts",
                column: "RentContractId");

            migrationBuilder.CreateIndex(
                name: "IX_CatchReceipts_UserId",
                table: "CatchReceipts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatchReceipts");
        }
    }
}

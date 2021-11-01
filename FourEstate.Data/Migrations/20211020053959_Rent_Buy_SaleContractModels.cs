using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourEstate.Data.Migrations
{
    public partial class Rent_Buy_SaleContractModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateType = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormulaContract = table.Column<int>(type: "int", nullable: false),
                    LocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CurrenyType = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyContracts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuyContracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyContracts_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfContract = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateType = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeStartRent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeEndRent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormulaContract = table.Column<int>(type: "int", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentContracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentContracts_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateType = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormulaContract = table.Column<int>(type: "int", nullable: false),
                    LocationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CurrenyType = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleContracts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleContracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleContracts_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyContracts_CustomerId",
                table: "BuyContracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyContracts_RealEstateId",
                table: "BuyContracts",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyContracts_UserId",
                table: "BuyContracts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RentContracts_CustomerId",
                table: "RentContracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentContracts_RealEstateId",
                table: "RentContracts",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleContracts_CustomerId",
                table: "SaleContracts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleContracts_RealEstateId",
                table: "SaleContracts",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleContracts_UserId",
                table: "SaleContracts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyContracts");

            migrationBuilder.DropTable(
                name: "RentContracts");

            migrationBuilder.DropTable(
                name: "SaleContracts");
        }
    }
}

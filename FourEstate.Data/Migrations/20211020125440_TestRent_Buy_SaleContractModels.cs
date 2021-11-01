using Microsoft.EntityFrameworkCore.Migrations;

namespace FourEstate.Data.Migrations
{
    public partial class TestRent_Buy_SaleContractModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stauts",
                table: "SaleContracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stauts",
                table: "RentContracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stauts",
                table: "BuyContracts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stauts",
                table: "SaleContracts");

            migrationBuilder.DropColumn(
                name: "Stauts",
                table: "RentContracts");

            migrationBuilder.DropColumn(
                name: "Stauts",
                table: "BuyContracts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace FourEstate.Data.Migrations
{
    public partial class InvoiceModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealEstateId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_RealEstateId",
                table: "Invoices",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_RealEstates_RealEstateId",
                table: "Invoices",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_RealEstates_RealEstateId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_RealEstateId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RealEstateId",
                table: "Invoices");
        }
    }
}

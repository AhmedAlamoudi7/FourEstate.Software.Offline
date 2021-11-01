using Microsoft.EntityFrameworkCore.Migrations;

namespace FourEstate.Data.Migrations
{
    public partial class Receiptmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeStartRent",
                table: "Receipts",
                newName: "DateTimeStart");

            migrationBuilder.RenameColumn(
                name: "DateTimeEndRent",
                table: "Receipts",
                newName: "DateTimeEnd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeStart",
                table: "Receipts",
                newName: "DateTimeStartRent");

            migrationBuilder.RenameColumn(
                name: "DateTimeEnd",
                table: "Receipts",
                newName: "DateTimeEndRent");
        }
    }
}

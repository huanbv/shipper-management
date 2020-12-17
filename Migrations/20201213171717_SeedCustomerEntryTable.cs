using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class SeedCustomerEntryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EntryId",
                table: "Customers",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Entries_EntryId",
                table: "Customers",
                column: "EntryId",
                principalTable: "Entries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Entries_EntryId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_EntryId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "Customers");
        }
    }
}

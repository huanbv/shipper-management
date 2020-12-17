using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class SeedConsigneeEntryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ConsigneeEntry",
                columns: table => new
                {
                    ConsigneesId = table.Column<int>(type: "int", nullable: false),
                    EntriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsigneeEntry", x => new { x.ConsigneesId, x.EntriesId });
                    table.ForeignKey(
                        name: "FK_ConsigneeEntry_Consignees_ConsigneesId",
                        column: x => x.ConsigneesId,
                        principalTable: "Consignees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsigneeEntry_Entries_EntriesId",
                        column: x => x.EntriesId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerEntry",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    EntriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerEntry", x => new { x.CustomersId, x.EntriesId });
                    table.ForeignKey(
                        name: "FK_CustomerEntry_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerEntry_Entries_EntriesId",
                        column: x => x.EntriesId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsigneeEntry_EntriesId",
                table: "ConsigneeEntry",
                column: "EntriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEntry_EntriesId",
                table: "CustomerEntry",
                column: "EntriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsigneeEntry");

            migrationBuilder.DropTable(
                name: "CustomerEntry");

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
    }
}

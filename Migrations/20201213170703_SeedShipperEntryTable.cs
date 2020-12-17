using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class SeedShipperEntryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntryShipper",
                columns: table => new
                {
                    EntriesId = table.Column<int>(type: "int", nullable: false),
                    ShippersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryShipper", x => new { x.EntriesId, x.ShippersId });
                    table.ForeignKey(
                        name: "FK_EntryShipper_Entries_EntriesId",
                        column: x => x.EntriesId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryShipper_Shippers_ShippersId",
                        column: x => x.ShippersId,
                        principalTable: "Shippers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryShipper_ShippersId",
                table: "EntryShipper",
                column: "ShippersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryShipper");
        }
    }
}

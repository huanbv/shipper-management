using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class SeedDriverEntryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverEntry",
                columns: table => new
                {
                    DriversId = table.Column<int>(type: "int", nullable: false),
                    EntriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverEntry", x => new { x.DriversId, x.EntriesId });
                    table.ForeignKey(
                        name: "FK_DriverEntry_Drivers_DriversId",
                        column: x => x.DriversId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverEntry_Entries_EntriesId",
                        column: x => x.EntriesId,
                        principalTable: "Entries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DriverEntry_EntriesId",
                table: "DriverEntry",
                column: "EntriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverEntry");
        }
    }
}

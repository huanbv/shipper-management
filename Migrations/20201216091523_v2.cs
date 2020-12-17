using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsigneeEntry");

            migrationBuilder.DropTable(
                name: "CustomerEntry");

            migrationBuilder.DropTable(
                name: "DriverEntry");

            migrationBuilder.DropTable(
                name: "EntryShipper");

            migrationBuilder.AddColumn<int>(
                name: "ConsigneeId1",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverId1",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShipperId1",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ConsigneeId1",
                table: "Entries",
                column: "ConsigneeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CustomerId1",
                table: "Entries",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_DriverId1",
                table: "Entries",
                column: "DriverId1");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ShipperId1",
                table: "Entries",
                column: "ShipperId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Consignees_ConsigneeId1",
                table: "Entries",
                column: "ConsigneeId1",
                principalTable: "Consignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Customers_CustomerId1",
                table: "Entries",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Drivers_DriverId1",
                table: "Entries",
                column: "DriverId1",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Shippers_ShipperId1",
                table: "Entries",
                column: "ShipperId1",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Consignees_ConsigneeId1",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Customers_CustomerId1",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Drivers_DriverId1",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Shippers_ShipperId1",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ConsigneeId1",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_CustomerId1",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_DriverId1",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ShipperId1",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ConsigneeId1",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "DriverId1",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ShipperId1",
                table: "Entries");

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
                name: "IX_ConsigneeEntry_EntriesId",
                table: "ConsigneeEntry",
                column: "EntriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerEntry_EntriesId",
                table: "CustomerEntry",
                column: "EntriesId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverEntry_EntriesId",
                table: "DriverEntry",
                column: "EntriesId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryShipper_ShippersId",
                table: "EntryShipper",
                column: "ShippersId");
        }
    }
}

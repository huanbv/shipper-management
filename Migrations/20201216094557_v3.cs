using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ConsigneeId1",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "DriverId1",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "ShipperId1",
                table: "Entries",
                newName: "ConsigneeFK");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_ShipperId1",
                table: "Entries",
                newName: "IX_Entries_ConsigneeFK");

            migrationBuilder.AddColumn<int>(
                name: "ConsigneeId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShipperId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ConsigneeId",
                table: "Entries",
                column: "ConsigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_CustomerId",
                table: "Entries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_DriverId",
                table: "Entries",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ShipperId",
                table: "Entries",
                column: "ShipperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Consignees_ConsigneeFK",
                table: "Entries",
                column: "ConsigneeFK",
                principalTable: "Consignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Consignees_ConsigneeId",
                table: "Entries",
                column: "ConsigneeId",
                principalTable: "Consignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Customers_CustomerId",
                table: "Entries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Drivers_DriverId",
                table: "Entries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Shippers_ShipperId",
                table: "Entries",
                column: "ShipperId",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Consignees_ConsigneeFK",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Consignees_ConsigneeId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Customers_CustomerId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Drivers_DriverId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Shippers_ShipperId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ConsigneeId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_CustomerId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_DriverId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ShipperId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ConsigneeId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ShipperId",
                table: "Entries");

            migrationBuilder.RenameColumn(
                name: "ConsigneeFK",
                table: "Entries",
                newName: "ShipperId1");

            migrationBuilder.RenameIndex(
                name: "IX_Entries_ConsigneeFK",
                table: "Entries",
                newName: "IX_Entries_ShipperId1");

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
    }
}

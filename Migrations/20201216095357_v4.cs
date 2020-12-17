using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Consignees_ConsigneeFK",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Drivers_DriverId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Shippers_ShipperId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ConsigneeFK",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ConsigneeFK",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "ShipperId",
                table: "Entries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Entries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Drivers_DriverId",
                table: "Entries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Shippers_ShipperId",
                table: "Entries",
                column: "ShipperId",
                principalTable: "Shippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Drivers_DriverId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Shippers_ShipperId",
                table: "Entries");

            migrationBuilder.AlterColumn<int>(
                name: "ShipperId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsigneeFK",
                table: "Entries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ConsigneeFK",
                table: "Entries",
                column: "ConsigneeFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Consignees_ConsigneeFK",
                table: "Entries",
                column: "ConsigneeFK",
                principalTable: "Consignees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}

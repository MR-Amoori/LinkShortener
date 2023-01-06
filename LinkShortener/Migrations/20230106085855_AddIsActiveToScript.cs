using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkShortener.Migrations
{
    public partial class AddIsActiveToScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Scripts");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Scripts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 1, 6, 12, 28, 54, 809, DateTimeKind.Local).AddTicks(8819));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Scripts");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Scripts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2023, 1, 5, 14, 7, 3, 944, DateTimeKind.Local).AddTicks(4417));
        }
    }
}

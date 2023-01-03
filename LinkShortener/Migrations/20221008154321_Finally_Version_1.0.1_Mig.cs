using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkShortener.Migrations
{
    public partial class Finally_Version_101_Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "RegisterDate" },
                values: new object[] { "mohamad.reza.amoori99@gmail.com", new DateTime(2022, 10, 8, 19, 13, 20, 696, DateTimeKind.Local).AddTicks(4307) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Email", "RegisterDate" },
                values: new object[] { "Mohamad.reza.amooi99@gmail.com", new DateTime(2022, 10, 8, 19, 6, 42, 757, DateTimeKind.Local).AddTicks(4772) });
        }
    }
}

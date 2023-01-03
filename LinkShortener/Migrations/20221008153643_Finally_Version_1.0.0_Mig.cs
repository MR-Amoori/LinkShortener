using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LinkShortener.Migrations
{
    public partial class Finally_Version_100_Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "IsAdmin", "NumberPhone", "Password", "RegisterDate", "UserName" },
                values: new object[] { 1, "mohamad.reza.amooi99@gmail.com", true, "09035170373", "mohamad021", new DateTime(2022, 10, 8, 19, 6, 42, 757, DateTimeKind.Local).AddTicks(4772), "محمدرضاعموری" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}

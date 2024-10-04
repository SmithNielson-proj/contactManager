using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Migrations
{
    public partial class Organization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateTime", "Organization" },
                values: new object[] { new DateTime(2024, 10, 1, 17, 58, 31, 85, DateTimeKind.Local).AddTicks(8325), "Utah Valley University" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 10, 1, 17, 58, 31, 85, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2024, 10, 1, 17, 58, 31, 85, DateTimeKind.Local).AddTicks(8375));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 9, 30, 20, 12, 40, 232, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 9, 30, 20, 12, 40, 232, DateTimeKind.Local).AddTicks(7413));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2024, 9, 30, 20, 12, 40, 232, DateTimeKind.Local).AddTicks(7416));
        }
    }
}

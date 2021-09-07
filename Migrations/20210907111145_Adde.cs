using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FOODEE.Migrations
{
    public partial class Adde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserRoles");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 7, 12, 11, 42, 501, DateTimeKind.Local).AddTicks(7321));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 7, 12, 11, 42, 501, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 7, 12, 11, 42, 501, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 7, 12, 11, 42, 502, DateTimeKind.Local).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PhoneNumber" },
                values: new object[] { new DateTime(2021, 9, 7, 12, 11, 42, 484, DateTimeKind.Local).AddTicks(282), "09039513977" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserRoles",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 13, 27, 55, 920, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 13, 27, 55, 920, DateTimeKind.Local).AddTicks(5115));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 13, 27, 55, 920, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 9, 6, 13, 27, 55, 924, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PhoneNumber" },
                values: new object[] { new DateTime(2021, 9, 6, 13, 27, 55, 902, DateTimeKind.Local).AddTicks(2303), 9039513977L });
        }
    }
}

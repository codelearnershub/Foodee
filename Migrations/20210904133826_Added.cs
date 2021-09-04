using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FOODEE.Migrations
{
    public partial class Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "DateLastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 4, 14, 38, 22, 880, DateTimeKind.Local).AddTicks(481), null, "SuperAdmin" },
                    { 2, new DateTime(2021, 9, 4, 14, 38, 22, 880, DateTimeKind.Local).AddTicks(781), null, "Admin" },
                    { 3, new DateTime(2021, 9, 4, 14, 38, 22, 880, DateTimeKind.Local).AddTicks(795), null, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "DateLastModified", "Email", "FirstName", "Gender", "HashSalt", "LastName", "PasswordHash", "PhoneNumber" },
                values: new object[] { 1, "Asero,Abk", new DateTime(2021, 9, 4, 14, 38, 22, 856, DateTimeKind.Local).AddTicks(6384), null, "olowonmiadejoke@gmail.com", "Habeebah", "Female", "oRG1o9cidyVnRFgsWQN7AA==", "Olowonmi", "HH0bJTATP53nCkvQPacCkjlviZs1bb+BpbyrtOhOHgc=", 9039513977L });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "DateLastModified", "Name", "RoleId", "UserId" },
                values: new object[] { 1, new DateTime(2021, 9, 4, 14, 38, 22, 881, DateTimeKind.Local).AddTicks(9783), null, null, 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

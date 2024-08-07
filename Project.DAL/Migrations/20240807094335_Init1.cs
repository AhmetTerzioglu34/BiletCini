using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "20c5e411-114e-4c21-a639-1badc2dd63c4", new DateTime(2024, 8, 7, 12, 43, 34, 441, DateTimeKind.Local).AddTicks(4954) });

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 8, 7, 12, 43, 34, 500, DateTimeKind.Local).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eceb5c44-6d5e-4a9e-80fa-5d94b6fc7287", new DateTime(2024, 8, 7, 12, 43, 34, 441, DateTimeKind.Local).AddTicks(5221), "AQAAAAIAAYagAAAAEIGTICN3pJwUATQmijZQpG/0bWEUdNJyztOXqsovx6oeSN3OYz1vjwcGmKv3SEP6xw==", "aa819b05-6f67-434c-9052-84bb87fd38f9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "Movies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate" },
                values: new object[] { "5cf365b2-aa69-4cee-aee9-c344ef65270c", new DateTime(2024, 7, 30, 17, 17, 2, 987, DateTimeKind.Local).AddTicks(4905) });

            migrationBuilder.UpdateData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 7, 30, 17, 17, 3, 55, DateTimeKind.Local).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddcc8df0-f7bc-4a15-8166-e2c5c3226a84", new DateTime(2024, 7, 30, 17, 17, 2, 987, DateTimeKind.Local).AddTicks(5144), "AQAAAAIAAYagAAAAEBUmHJkrJkRINZCVqpv02WwiKWZDUwgWjmBePEfsjKYrKsRjjXvtZB67hFfO4P+UnQ==", "f6d3cd98-a128-4d26-afd2-a6611ef9bb63" });
        }
    }
}

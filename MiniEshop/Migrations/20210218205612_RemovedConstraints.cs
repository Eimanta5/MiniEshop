using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniEshop.Migrations
{
    public partial class RemovedConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShoppingCart",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 2, 18, 20, 56, 12, 27, DateTimeKind.Utc).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 2, 18, 20, 56, 12, 25, DateTimeKind.Utc).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 2, 18, 20, 56, 12, 25, DateTimeKind.Utc).AddTicks(9944));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShoppingCart",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 2, 18, 20, 55, 16, 520, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 2, 18, 20, 55, 16, 517, DateTimeKind.Utc).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 2, 18, 20, 55, 16, 517, DateTimeKind.Utc).AddTicks(7105));
        }
    }
}

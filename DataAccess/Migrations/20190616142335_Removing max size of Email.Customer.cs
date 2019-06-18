using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemovingmaxsizeofEmailCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DropDate", "PickDate" },
                values: new object[] { new DateTime(2019, 6, 16, 16, 23, 33, 939, DateTimeKind.Local).AddTicks(8446), new DateTime(2019, 6, 16, 16, 23, 33, 936, DateTimeKind.Local).AddTicks(6017) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DropDate", "PickDate" },
                values: new object[] { new DateTime(2019, 6, 12, 19, 50, 17, 381, DateTimeKind.Local).AddTicks(6041), new DateTime(2019, 6, 12, 19, 50, 17, 378, DateTimeKind.Local).AddTicks(8797) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddingisDeletedcolumntoExtraAddonRenttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "RentExtraAddons",
                nullable: false,
                defaultValueSql: "0");

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DropDate", "PickDate" },
                values: new object[] { new DateTime(2019, 6, 12, 19, 50, 17, 381, DateTimeKind.Local).AddTicks(6041), new DateTime(2019, 6, 12, 19, 50, 17, 378, DateTimeKind.Local).AddTicks(8797) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RentExtraAddons");

            migrationBuilder.UpdateData(
                table: "Rents",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DropDate", "PickDate" },
                values: new object[] { new DateTime(2019, 6, 10, 13, 17, 11, 470, DateTimeKind.Local).AddTicks(216), new DateTime(2019, 6, 10, 13, 17, 11, 467, DateTimeKind.Local).AddTicks(3714) });
        }
    }
}

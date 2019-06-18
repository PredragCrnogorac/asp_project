using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ChangingvehicleCostPerDayinsteadofCostPerHourandstateofvehiclerentedornot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CostPerHour",
                table: "Vehicles",
                newName: "CostPerDay");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Rented",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "CostPerDay" },
                values: new object[] { "Blue", 20.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Rented",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "CostPerDay",
                table: "Vehicles",
                newName: "CostPerHour");

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "CostPerHour",
                value: 2.8999999999999999);
        }
    }
}

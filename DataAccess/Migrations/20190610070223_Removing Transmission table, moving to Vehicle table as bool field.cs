using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class RemovingTransmissiontablemovingtoVehicletableasboolfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Transmissions_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Transmissions");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Vehicles");

            migrationBuilder.AddColumn<bool>(
                name: "Automatic",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    Adress = table.Column<string>(maxLength: 30, nullable: false),
                    Price = table.Column<double>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Adress", "ModifiedAt", "Price" },
                values: new object[] { 8, "Default location", null, 10.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropColumn(
                name: "Automatic",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 8);

            migrationBuilder.CreateTable(
                name: "Transmissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    IsDeleted = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmissions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transmissions",
                columns: new[] { "Id", "ModifiedAt", "Name" },
                values: new object[] { 8, null, "Default transimtion" });

            migrationBuilder.UpdateData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8,
                column: "TransmissionId",
                value: 8);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Transmissions_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

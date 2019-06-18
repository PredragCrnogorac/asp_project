using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Addedtransmissiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Vehicles",
                nullable: false,
                defaultValue: 8);

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Transmission",
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
                name: "FK_Vehicles_Transmission_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId",
                principalTable: "Transmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Transmission_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Vehicles");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Smalltestfixfortransmissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Transmission_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transmission",
                table: "Transmission");

            migrationBuilder.RenameTable(
                name: "Transmission",
                newName: "Transmissions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transmissions",
                table: "Transmissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Transmissions_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId",
                principalTable: "Transmissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Transmissions_TransmissionId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transmissions",
                table: "Transmissions");

            migrationBuilder.RenameTable(
                name: "Transmissions",
                newName: "Transmission");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transmission",
                table: "Transmission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Transmission_TransmissionId",
                table: "Vehicles",
                column: "TransmissionId",
                principalTable: "Transmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

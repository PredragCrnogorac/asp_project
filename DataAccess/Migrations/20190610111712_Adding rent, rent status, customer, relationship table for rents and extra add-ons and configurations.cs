using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Addingrentrentstatuscustomerrelationshiptableforrentsandextraaddonsandconfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentStatus",
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
                    table.PrimaryKey("PK_RentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    UserId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    DropLocationId = table.Column<int>(nullable: false),
                    PickDate = table.Column<DateTime>(nullable: false),
                    DropDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PickAdress = table.Column<string>(nullable: true),
                    DropAdress = table.Column<string>(nullable: true),
                    VehicleCostPerDay = table.Column<double>(nullable: false),
                    TotallPrice = table.Column<double>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rents_Locations_DropLocationId",
                        column: x => x.DropLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rents_RentStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "RentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rents_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentExtraAddons",
                columns: table => new
                {
                    RentId = table.Column<int>(nullable: false),
                    ExtraAddonId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentExtraAddons", x => new { x.RentId, x.ExtraAddonId });
                    table.ForeignKey(
                        name: "FK_RentExtraAddons_ExtraAddons_ExtraAddonId",
                        column: x => x.ExtraAddonId,
                        principalTable: "ExtraAddons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentExtraAddons_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "RentStatus",
                columns: new[] { "Id", "ModifiedAt", "Name" },
                values: new object[] { 8, null, "Default stats" });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "CustomerId", "DropAdress", "DropDate", "DropLocationId", "Email", "FirstName", "LastName", "LocationId", "ModifiedAt", "PickAdress", "PickDate", "StatusId", "TotallPrice", "UserId", "VehicleCostPerDay", "VehicleId" },
                values: new object[] { 8, 8, "Svetolika Randovica 2a", new DateTime(2019, 6, 10, 13, 17, 11, 470, DateTimeKind.Local).AddTicks(216), 8, "pbcrnogorac@gmail.com", "Predrag", "Crnogorac", 8, null, "Svetolika Rankovica 2a", new DateTime(2019, 6, 10, 13, 17, 11, 467, DateTimeKind.Local).AddTicks(3714), 8, 40.0, 12, 20.0, 8 });

            migrationBuilder.InsertData(
                table: "RentExtraAddons",
                columns: new[] { "RentId", "ExtraAddonId", "Price" },
                values: new object[] { 8, 8, 20.0 });

            migrationBuilder.CreateIndex(
                name: "IX_RentExtraAddons_ExtraAddonId",
                table: "RentExtraAddons",
                column: "ExtraAddonId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CustomerId",
                table: "Rents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_DropLocationId",
                table: "Rents",
                column: "DropLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_LocationId",
                table: "Rents",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_StatusId",
                table: "Rents",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_VehicleId",
                table: "Rents",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentExtraAddons");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "RentStatus");
        }
    }
}

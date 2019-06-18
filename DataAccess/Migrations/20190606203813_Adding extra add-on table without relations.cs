using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Addingextraaddontablewithoutrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtraAddons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<int>(nullable: true, defaultValueSql: "0"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Price = table.Column<double>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraAddons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExtraAddons",
                columns: new[] { "Id", "ModifiedAt", "Name", "Price" },
                values: new object[] { 8, null, "Default add-on", 20.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraAddons");
        }
    }
}

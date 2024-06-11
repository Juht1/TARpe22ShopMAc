using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe22ShopVaitmaa.Data.Migrations
{
    public partial class dbchangeRSImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilesToApi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExistingFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesToApi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilesToApi_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilesToApi_RealEstateId",
                table: "FilesToApi",
                column: "RealEstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesToApi");
        }
    }
}

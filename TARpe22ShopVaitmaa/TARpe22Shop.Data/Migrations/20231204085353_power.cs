using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe22ShopVaitmaa.Data.Migrations
{
    public partial class power : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "FilesToDatabase",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelCapacity = table.Column<int>(type: "int", nullable: false),
                    FuelConsumption = table.Column<int>(type: "int", nullable: false),
                    PassengerCount = table.Column<int>(type: "int", nullable: false),
                    EnginePower = table.Column<int>(type: "int", nullable: false),
                    DoesHaveAutopilot = table.Column<bool>(type: "bit", nullable: false),
                    CrewCount = table.Column<int>(type: "int", nullable: false),
                    CargoWeight = table.Column<int>(type: "int", nullable: false),
                    DoesHaveLifeSupportSystems = table.Column<bool>(type: "bit", nullable: false),
                    BuiltDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaintenanceCount = table.Column<int>(type: "int", nullable: false),
                    FullTripsCount = table.Column<int>(type: "int", nullable: false),
                    MaidenLaunch = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "FilesToDatabase");
        }
    }
}

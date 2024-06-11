using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe22ShopVaitmaa.Data.Migrations
{
    public partial class realestate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ListingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    ContactPhone = table.Column<int>(type: "int", nullable: false),
                    ContactFax = table.Column<int>(type: "int", nullable: false),
                    SquareMeters = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: true),
                    FloorCount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: true),
                    BedroomCount = table.Column<int>(type: "int", nullable: true),
                    BathroomCount = table.Column<int>(type: "int", nullable: true),
                    WhenEstateListedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPropertySold = table.Column<bool>(type: "bit", nullable: false),
                    DoesHaveSwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    BuiltAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstates");
        }
    }
}

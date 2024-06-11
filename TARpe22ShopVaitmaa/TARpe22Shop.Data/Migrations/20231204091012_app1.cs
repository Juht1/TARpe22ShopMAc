using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe22ShopVaitmaa.Data.Migrations
{
    public partial class app1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrewCount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DoesHaveLifeSupportSystems",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrewCount",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DoesHaveLifeSupportSystems",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalApp.Infrastructure.Migrations
{
    public partial class AddCountyFieldToFestival : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Festivals",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "County",
                table: "Festivals");
        }
    }
}

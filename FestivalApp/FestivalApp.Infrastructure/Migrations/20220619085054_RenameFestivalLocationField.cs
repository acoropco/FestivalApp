using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestivalApp.Infrastructure.Migrations
{
    public partial class RenameFestivalLocationField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Festivals",
                newName: "Street");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Festivals",
                newName: "Location");
        }
    }
}

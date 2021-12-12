using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.Infrastructure.Migrations
{
    public partial class FixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Biogaphy",
                table: "Actors",
                newName: "Biography");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Biography",
                table: "Actors",
                newName: "Biogaphy");
        }
    }
}

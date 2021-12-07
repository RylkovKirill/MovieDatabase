using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.Infrastructure.Migrations
{
    public partial class AddActorAndDirectorCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Directors",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Actors",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Actors");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.Infrastructure.Migrations
{
    public partial class AddActorAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "Actors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biogaphy",
                table: "Actors",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Biogaphy",
                table: "Actors");
        }
    }
}

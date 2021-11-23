using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.Infrastructure.Migrations
{
    public partial class AddHistoryEntityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReviewId",
                table: "ReviewsHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "MoviesHistory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "ReviewsHistory");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MoviesHistory");
        }
    }
}

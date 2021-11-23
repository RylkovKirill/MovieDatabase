using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.Infrastructure.Migrations
{
    public partial class AddHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoviesHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    BoxOffice = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Runtime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DateOfRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RatingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistributorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesHistory_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoviesHistory_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoviesHistory_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewsHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewsHistory_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviesHistory_DirectorId",
                table: "MoviesHistory",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesHistory_DistributorId",
                table: "MoviesHistory",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesHistory_Id",
                table: "MoviesHistory",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesHistory_RatingId",
                table: "MoviesHistory",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsHistory_Id",
                table: "ReviewsHistory",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsHistory_MovieId",
                table: "ReviewsHistory",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsHistory_UserId",
                table: "ReviewsHistory",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesHistory");

            migrationBuilder.DropTable(
                name: "ReviewsHistory");
        }
    }
}

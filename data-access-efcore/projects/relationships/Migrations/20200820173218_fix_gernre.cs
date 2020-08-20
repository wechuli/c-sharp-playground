using Microsoft.EntityFrameworkCore.Migrations;

namespace relationships.Migrations
{
    public partial class fix_gernre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookgenres_authors_AuthorId",
                table: "bookgenres");

            migrationBuilder.DropIndex(
                name: "IX_bookgenres_AuthorId",
                table: "bookgenres");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "bookgenres");

            migrationBuilder.CreateIndex(
                name: "IX_bookgenres_GenreId",
                table: "bookgenres",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookgenres_genres_GenreId",
                table: "bookgenres",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookgenres_genres_GenreId",
                table: "bookgenres");

            migrationBuilder.DropIndex(
                name: "IX_bookgenres_GenreId",
                table: "bookgenres");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "bookgenres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookgenres_AuthorId",
                table: "bookgenres",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookgenres_authors_AuthorId",
                table: "bookgenres",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

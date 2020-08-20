using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationsPractise.Migrations
{
    public partial class add_index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_books_isbn",
                table: "books",
                column: "isbn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_books_isbn",
                table: "books");
        }
    }
}

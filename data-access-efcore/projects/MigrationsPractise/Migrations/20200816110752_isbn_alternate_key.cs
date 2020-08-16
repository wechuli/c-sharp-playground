using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationsPractise.Migrations
{
    public partial class isbn_alternate_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "isbn",
                table: "books",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_books_isbn",
                table: "books",
                column: "isbn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_books_isbn",
                table: "books");

            migrationBuilder.AlterColumn<string>(
                name: "isbn",
                table: "books",
                type: "character varying(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);
        }
    }
}

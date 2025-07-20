using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeBookmarks.Migrations
{
    /// <inheritdoc />
    public partial class Intiial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Animes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Slug",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Animes");
        }
    }
}

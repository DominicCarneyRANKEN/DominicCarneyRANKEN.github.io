using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeBookmarks.Migrations
{
    /// <inheritdoc />
    public partial class Anime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animes",
                columns: new[] { "Id", "Description", "Genre", "ImageUrl", "Title" },
                values: new object[] { 1, "The story revolves around Rin Okumura, a teenager who discovers that he and his twin brother Yukio are the sons of Satan, born from a human woman, and he is the inheritor of Satan's powers.", "Action", "https://i.ebayimg.com/images/g/XvIAAOSwbgNgJS72/s-l1200.jpg", "Blue Exorcist" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animes");
        }
    }
}

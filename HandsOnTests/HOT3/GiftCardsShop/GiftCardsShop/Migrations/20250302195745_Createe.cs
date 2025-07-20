using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GiftCardsShop.Migrations
{
    /// <inheritdoc />
    public partial class Createe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Description", "Img", "Name", "Price", "Slug" },
                values: new object[,]
                {
                    { 1, "Fortnite V Bucks used to buy cosmetics from the item shop", "", "Fortnite 1000 V-Bucks", 8.9900000000000002, "fortnite-v-bucks" },
                    { 2, "PS Gift Card used to make purchases on PS Store", "", "PS 25$ Gift Card", 25.0, "ps-gift-card" },
                    { 3, "Enhance your PlayStation experience with core features, including online multiplayer access, monthly games, exclusive discounts, and more.", "", "PS Plus Essential 12 Month Subscription", 79.989999999999995, "ps-plus" },
                    { 4, "Give the gift of delivery with a DoorDash gift card. The DoorDash app connects your favorite people with the best of their neighborhood.", "", "DoorDash 50$ Gift Card", 50.0, "doordash-gift-card" },
                    { 5, "Roblox, Roblox Gift Card", "", "Roblox $25 Gift Card", 25.0, "roblox-gift-card" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HOT3.Migrations
{
    /// <inheritdoc />
    public partial class Initil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Developer", "Genre", "ImageFileName", "Name", "Price", "Publisher", "Year" },
                values: new object[,]
                {
                    { 1, "Nintendo", "Action-adventure", "zelda_breath_of_the_wild.jpg", "The Legend of Zelda: Breath of the Wild", 59.99m, "Nintendo", 2017 },
                    { 2, "Santa Monica Studio", "Action-adventure", "god_of_war.jpg", "God of War", 49.99m, "Sony Interactive Entertainment", 2018 },
                    { 3, "Rockstar Games", "Action-adventure", "red_dead_redemption_2.jpg", "Red Dead Redemption 2", 59.99m, "Rockstar Games", 2018 },
                    { 4, "CD Projekt Red", "Action RPG", "witcher_3_wild_hunt.jpg", "The Witcher 3: Wild Hunt", 39.99m, "CD Projekt", 2015 },
                    { 5, "Mojang Studios", "Sandbox, Survival", "minecraft.jpg", "Minecraft", 26.95m, "Mojang Studios", 2011 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}

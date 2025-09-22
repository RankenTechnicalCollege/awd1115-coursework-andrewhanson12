using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HOT2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescShort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescLong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDescLong", "ProductDescShort", "ProductImage", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[,]
                {
                    { 1, null, "", "", "", "AeroFlo ATB Wheels", 189m, 40 },
                    { 2, null, "", "", "", "Clear Shade 85-T Glasses", 45m, 14 },
                    { 3, null, "", "", "", "Cosmic Elite Road Warrior Wheels", 165m, 22 },
                    { 4, null, "", "", "", "Cycle-Doc Pro Repair Stand", 166m, 12 },
                    { 5, null, "", "", "", "Dog Ear Aero-Flow Floor Pump", 55m, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

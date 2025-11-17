using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripsLog.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "AccommodationId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "hotel@hotel.com", "Hotel", "555-555-5555" },
                    { 2, "staff@staybridge.com", "Staybridge Suites", "212-555-1234" },
                    { 3, null, "Camping", null }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "ActivityId", "Name" },
                values: new object[,]
                {
                    { 1, "Football Game" },
                    { 2, "Beach" },
                    { 3, "Hiking" },
                    { 4, "Museum" },
                    { 5, "Swimming" },
                    { 6, "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "Name" },
                values: new object[,]
                {
                    { 1, "Green Bay, Wisconsin" },
                    { 2, "New York, New York" },
                    { 3, "Tampa Bay, Florida" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "ActivityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "DestinationId",
                keyValue: 3);
        }
    }
}

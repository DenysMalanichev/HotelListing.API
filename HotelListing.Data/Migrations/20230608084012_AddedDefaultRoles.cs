using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "48152ce5-c8e7-4da2-9f46-18811c2d3ccc", "dab0141e-66c3-4898-b552-eb059b93961f", "User", "USER" },
                    { "c7580a3b-c4b4-4209-bdff-ffe7d6177132", "eb31b8dd-73b8-40e2-a65e-1661e5f0f53f", "Administator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48152ce5-c8e7-4da2-9f46-18811c2d3ccc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7580a3b-c4b4-4209-bdff-ffe7d6177132");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExploreNepalWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22f6d8c0-12cf-4d50-b6cb-f125e8a3d523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "262f8bb8-2697-44d5-8ac4-b4d51c5abcec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2637fb95-6237-4d49-9014-89554d96f211", null, "User", "USER" },
                    { "cc9c9ce9-4de5-4177-9454-3bd764b50045", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2637fb95-6237-4d49-9014-89554d96f211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc9c9ce9-4de5-4177-9454-3bd764b50045");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22f6d8c0-12cf-4d50-b6cb-f125e8a3d523", null, "User", "USER" },
                    { "262f8bb8-2697-44d5-8ac4-b4d51c5abcec", null, "Admin", "ADMIN" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExploreNepalWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class destination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d4871c9-b3e4-49ed-8490-3451513d6bb5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc410c3c-199b-4ff2-9469-2d967e85f96b");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Why",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22f6d8c0-12cf-4d50-b6cb-f125e8a3d523", null, "User", "USER" },
                    { "262f8bb8-2697-44d5-8ac4-b4d51c5abcec", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22f6d8c0-12cf-4d50-b6cb-f125e8a3d523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "262f8bb8-2697-44d5-8ac4-b4d51c5abcec");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "Why",
                table: "Destinations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d4871c9-b3e4-49ed-8490-3451513d6bb5", null, "Admin", "ADMIN" },
                    { "cc410c3c-199b-4ff2-9469-2d967e85f96b", null, "User", "USER" }
                });
        }
    }
}

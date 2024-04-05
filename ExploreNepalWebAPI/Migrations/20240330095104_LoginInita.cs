using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExploreNepalWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class LoginInita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6886f4ec-a2c3-4cf4-8aaf-8a2c28484b2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a37fade7-84ab-4eed-a09a-e74a4d3f7c41");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02875153-94bf-4448-909e-b39765970438", null, "User", "USER" },
                    { "f06b8648-9084-4837-a03a-00edea31dd0e", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02875153-94bf-4448-909e-b39765970438");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f06b8648-9084-4837-a03a-00edea31dd0e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6886f4ec-a2c3-4cf4-8aaf-8a2c28484b2c", null, "Admin", "ADMIN" },
                    { "a37fade7-84ab-4eed-a09a-e74a4d3f7c41", null, "User", "USER" }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExploreNepalWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class contactus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2637fb95-6237-4d49-9014-89554d96f211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc9c9ce9-4de5-4177-9454-3bd764b50045");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8a0f63ce-65ef-44b2-b23c-7833bbff9b87", null, "User", "USER" },
                    { "a9016f82-5faa-4bcf-8a4a-b7016df7adab", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a0f63ce-65ef-44b2-b23c-7833bbff9b87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9016f82-5faa-4bcf-8a4a-b7016df7adab");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserInfos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2637fb95-6237-4d49-9014-89554d96f211", null, "User", "USER" },
                    { "cc9c9ce9-4de5-4177-9454-3bd764b50045", null, "Admin", "ADMIN" }
                });
        }
    }
}

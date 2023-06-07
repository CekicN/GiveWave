using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GiveWaveAPI.Migrations
{
    /// <inheritdoc />
    public partial class Userss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21e076a7-3ec4-4ac1-a6a6-c4301862b4e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4516a2f5-8585-4f10-b988-ee3de00d490a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80d1552e-583d-47fa-a2ec-578372df6d10");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65923d56-f0da-4a48-8fad-ac07b2d85734", "2", "User", "User" },
                    { "bf0f7d8c-fa5e-4c99-8be7-7d8e2bbd7c33", "3", "Friend", "Friend" },
                    { "d3b9f638-b925-4b85-90a1-930389bd354d", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65923d56-f0da-4a48-8fad-ac07b2d85734");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf0f7d8c-fa5e-4c99-8be7-7d8e2bbd7c33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3b9f638-b925-4b85-90a1-930389bd354d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21e076a7-3ec4-4ac1-a6a6-c4301862b4e7", "1", "Admin", "Admin" },
                    { "4516a2f5-8585-4f10-b988-ee3de00d490a", "2", "User", "User" },
                    { "80d1552e-583d-47fa-a2ec-578372df6d10", "3", "Friend", "Friend" }
                });
        }
    }
}

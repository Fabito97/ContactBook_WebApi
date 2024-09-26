using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DGNET002_Week9_10_Task.Migrations
{
    /// <inheritdoc />
    public partial class addPhotoColumnToContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9faccd5a-72d4-4117-8bc2-7c8c34dcae44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4ee65b5-0079-4430-8b87-f9dd06d9fcc4");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhoto",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02702af6-080c-4a11-b865-842ac67ec6f0", null, "Admin", "ADMIN" },
                    { "20908ee8-8908-4923-91e8-f5b3b4471d83", null, "Regular", "REGULAR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02702af6-080c-4a11-b865-842ac67ec6f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20908ee8-8908-4923-91e8-f5b3b4471d83");

            migrationBuilder.DropColumn(
                name: "ContactPhoto",
                table: "Contacts");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9faccd5a-72d4-4117-8bc2-7c8c34dcae44", null, "Regular", "REGULAR" },
                    { "e4ee65b5-0079-4430-8b87-f9dd06d9fcc4", null, "Admin", "ADMIN" }
                });
        }
    }
}

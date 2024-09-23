using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DGNET002_Week9_10_Task.Migrations
{
    /// <inheritdoc />
    public partial class AddAdditionalColumnToContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4f8299-5f2f-4db2-8484-d32df53213a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbdbe1cd-4a60-4ab5-b7f0-4618ab1fb6b2");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Contacts",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9faccd5a-72d4-4117-8bc2-7c8c34dcae44", null, "Regular", "REGULAR" },
                    { "e4ee65b5-0079-4430-8b87-f9dd06d9fcc4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Address",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Contacts",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "be4f8299-5f2f-4db2-8484-d32df53213a1", null, "Regular", "REGULAR" },
                    { "fbdbe1cd-4a60-4ab5-b7f0-4618ab1fb6b2", null, "Admin", "ADMIN" }
                });
        }
    }
}

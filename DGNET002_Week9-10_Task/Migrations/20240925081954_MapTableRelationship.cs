using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DGNET002_Week9_10_Task.Migrations
{
    /// <inheritdoc />
    public partial class MapTableRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02702af6-080c-4a11-b865-842ac67ec6f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20908ee8-8908-4923-91e8-f5b3b4471d83");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "AspNetUsers",
                newName: "ProfileImage");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhoto",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Contacts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "20357a63-02c9-4745-80be-6b3538cf07d9", null, "Regular", "REGULAR" },
                    { "a0ec6242-bb72-4bc8-9237-ce73e7a01840", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_UserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20357a63-02c9-4745-80be-6b3538cf07d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0ec6242-bb72-4bc8-9237-ce73e7a01840");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ProfileImage",
                table: "AspNetUsers",
                newName: "CompanyName");

            migrationBuilder.AlterColumn<string>(
                name: "ContactPhoto",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02702af6-080c-4a11-b865-842ac67ec6f0", null, "Admin", "ADMIN" },
                    { "20908ee8-8908-4923-91e8-f5b3b4471d83", null, "Regular", "REGULAR" }
                });
        }
    }
}

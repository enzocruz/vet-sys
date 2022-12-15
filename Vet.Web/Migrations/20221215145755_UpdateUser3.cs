using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet.Web.Migrations
{
    public partial class UpdateUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02050d42-541d-4e8f-b894-1cec1893f18d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cdd3dc99-b409-45b0-a682-c3441d677a0d", 0, "dfb4a9f2-81fb-49df-a191-933dd1589948", "test@gmail.com", true, false, null, "test@gamil.com", "admin", "AQAAAAEAACcQAAAAEIWpgjZhWUr73VP3OAgzrWC1C3WOAfsib6P9q335w3MDCmIdTiOR5NLGdTO8096zHA==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdd3dc99-b409-45b0-a682-c3441d677a0d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02050d42-541d-4e8f-b894-1cec1893f18d", 0, "846a3af0-6a98-4e1b-b700-d209b3a6a280", "test@gmail.com", true, false, null, "test@gamil.com", "admin", "AQAAAAEAACcQAAAAEHlee10niOu6saS9T5GR7vfvN+to2nss6XmR8c0baukdLkHX7ed4c9gAK1LInBgBuQ==", null, false, "", false, "admin" });
        }
    }
}

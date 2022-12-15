using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet.Web.Migrations
{
    public partial class UpdateUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd306e60-ced3-40d6-8a32-a09829172888");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02050d42-541d-4e8f-b894-1cec1893f18d", 0, "846a3af0-6a98-4e1b-b700-d209b3a6a280", "test@gmail.com", true, false, null, "test@gamil.com", "admin", "AQAAAAEAACcQAAAAEHlee10niOu6saS9T5GR7vfvN+to2nss6XmR8c0baukdLkHX7ed4c9gAK1LInBgBuQ==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02050d42-541d-4e8f-b894-1cec1893f18d");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fd306e60-ced3-40d6-8a32-a09829172888", 0, "8e75a5a0-d6c8-44f7-8361-2a8dab2483ef", "test@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJ6IKkNUjf7maBTgLWCiDI7qsxo9S+ztOUs1aMJQIPJp88DoGfZLqfjI8DH7ykGMAw==", null, false, "3b270893-d014-42dc-9bc3-fc8a834f0bc2", false, "admin" });
        }
    }
}

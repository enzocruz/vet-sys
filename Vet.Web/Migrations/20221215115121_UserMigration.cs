using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet.Web.Migrations
{
    public partial class UserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eb1d64e2-aff6-44d2-9956-42cc342f69b8", 0, "b2c547d6-6f9b-4d70-aacc-8d7e998187cd", "test@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENHCwgMQcZ7oayC2g6PE63+nXQ7FjY8ZnfdrLtbViJPuPntDTPHkyTRjHslR+/N95w==", null, false, "8f3e7cf5-37a4-460b-a28a-88ef27d59d0e", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb1d64e2-aff6-44d2-9956-42cc342f69b8");
        }
    }
}

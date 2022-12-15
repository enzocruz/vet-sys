using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet.Web.Migrations
{
    public partial class UpdateUser6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdd3dc99-b409-45b0-a682-c3441d677a0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7be84961-f687-443e-baf2-1c7bf9da9b10", "p@$$w0rd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdd3dc99-b409-45b0-a682-c3441d677a0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f3e042a3-53b7-4b32-9ac3-20ba5a629daa", "AQAAAAEAACcQAAAAEEBQrhxNrcxNLZXPHGf4rLVta8wc4SdaL4b4V7yhN4rZtLbAQNDN1VfgDTtibUe0nA==" });
        }
    }
}

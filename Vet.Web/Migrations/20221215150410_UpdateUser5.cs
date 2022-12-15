using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet.Web.Migrations
{
    public partial class UpdateUser5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdd3dc99-b409-45b0-a682-c3441d677a0d",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "f3e042a3-53b7-4b32-9ac3-20ba5a629daa", "test@gmail.com", "AQAAAAEAACcQAAAAEEBQrhxNrcxNLZXPHGf4rLVta8wc4SdaL4b4V7yhN4rZtLbAQNDN1VfgDTtibUe0nA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdd3dc99-b409-45b0-a682-c3441d677a0d",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "ff947bc8-55ae-4c8c-952b-52fd7e281202", "test@gamil.com", "AQAAAAEAACcQAAAAEG6+OguzxqxPsaaB5Ml5hdmkaHp4U+NNGWDZvnmv34VOqCMQsxHgiQPBy3Rcyx0ylg==" });
        }
    }
}

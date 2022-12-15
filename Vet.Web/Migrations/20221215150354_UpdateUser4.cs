using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet.Web.Migrations
{
    public partial class UpdateUser4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdd3dc99-b409-45b0-a682-c3441d677a0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ff947bc8-55ae-4c8c-952b-52fd7e281202", "AQAAAAEAACcQAAAAEG6+OguzxqxPsaaB5Ml5hdmkaHp4U+NNGWDZvnmv34VOqCMQsxHgiQPBy3Rcyx0ylg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdd3dc99-b409-45b0-a682-c3441d677a0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dfb4a9f2-81fb-49df-a191-933dd1589948", "AQAAAAEAACcQAAAAEIWpgjZhWUr73VP3OAgzrWC1C3WOAfsib6P9q335w3MDCmIdTiOR5NLGdTO8096zHA==" });
        }
    }
}

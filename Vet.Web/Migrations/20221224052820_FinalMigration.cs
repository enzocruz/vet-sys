using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet.Web.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vacinations_ItemID",
                table: "Vacinations",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ItemID",
                table: "Prescriptions",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Items_ItemID",
                table: "Prescriptions",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacinations_Items_ItemID",
                table: "Vacinations",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Items_ItemID",
                table: "Prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacinations_Items_ItemID",
                table: "Vacinations");

            migrationBuilder.DropIndex(
                name: "IX_Vacinations_ItemID",
                table: "Vacinations");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_ItemID",
                table: "Prescriptions");
        }
    }
}

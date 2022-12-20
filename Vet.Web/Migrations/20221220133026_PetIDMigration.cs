using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vet.Web.Migrations
{
    public partial class PetIDMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Pets_PetsId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_PetsId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "PetsId",
                table: "History");

            migrationBuilder.AddColumn<int>(
                name: "PetID",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_History_PetID",
                table: "History",
                column: "PetID");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Pets_PetID",
                table: "History",
                column: "PetID",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Pets_PetID",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_PetID",
                table: "History");

            migrationBuilder.DropColumn(
                name: "PetID",
                table: "History");

            migrationBuilder.AddColumn<int>(
                name: "PetsId",
                table: "History",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_History_PetsId",
                table: "History",
                column: "PetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Pets_PetsId",
                table: "History",
                column: "PetsId",
                principalTable: "Pets",
                principalColumn: "Id");
        }
    }
}

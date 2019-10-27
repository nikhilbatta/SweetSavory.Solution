using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetSavory.Migrations
{
    public partial class IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Treats",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treats_CreatedById",
                table: "Treats",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Treats_AspNetUsers_CreatedById",
                table: "Treats",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treats_AspNetUsers_CreatedById",
                table: "Treats");

            migrationBuilder.DropIndex(
                name: "IX_Treats_CreatedById",
                table: "Treats");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Treats");
        }
    }
}

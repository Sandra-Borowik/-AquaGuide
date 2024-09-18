using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaGuide.Data.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Fishes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_UserId",
                table: "Fishes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fishes_AspNetUsers_UserId",
                table: "Fishes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fishes_AspNetUsers_UserId",
                table: "Fishes");

            migrationBuilder.DropIndex(
                name: "IX_Fishes_UserId",
                table: "Fishes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fishes");
        }
    }
}

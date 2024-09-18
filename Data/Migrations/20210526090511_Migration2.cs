using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaGuide.Data.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Parameters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parameters_UserId",
                table: "Parameters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_AspNetUsers_UserId",
                table: "Parameters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_AspNetUsers_UserId",
                table: "Parameters");

            migrationBuilder.DropIndex(
                name: "IX_Parameters_UserId",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Parameters");
        }
    }
}

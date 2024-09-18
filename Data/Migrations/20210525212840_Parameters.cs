using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaGuide.Data.Migrations
{
    public partial class Parameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Parameters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GH",
                table: "Parameters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KH",
                table: "Parameters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TDS",
                table: "Parameters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                table: "Parameters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Parameters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "GH",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "KH",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "TDS",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Parameters");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Parameters");
        }
    }
}

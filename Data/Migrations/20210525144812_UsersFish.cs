using Microsoft.EntityFrameworkCore.Migrations;

namespace AquaGuide.Data.Migrations
{
    public partial class UsersFish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fishes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Species = table.Column<string>(nullable: false),
                    Attitude = table.Column<string>(nullable: false),
                    Feeding = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    FishesID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fishes_Fishes_FishesID",
                        column: x => x.FishesID,
                        principalTable: "Fishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fishes_FishesID",
                table: "Fishes",
                column: "FishesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fishes");
        }
    }
}

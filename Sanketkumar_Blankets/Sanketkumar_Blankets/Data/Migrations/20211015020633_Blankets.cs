using Microsoft.EntityFrameworkCore.Migrations;

namespace Sanketkumar_Blankets.Data.Migrations
{
    public partial class Blankets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Blankets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Blankets",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Material",
                table: "Blankets");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Blankets");
        }
    }
}

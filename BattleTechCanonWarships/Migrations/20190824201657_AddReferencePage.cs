using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleTechCanonWarships.Migrations
{
    public partial class AddReferencePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "Reference",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Page",
                table: "Reference");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleTechCanonWarships.Migrations
{
    public partial class AddPreviousValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreviousValue",
                table: "PropertyChange",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousValue",
                table: "PropertyChange");
        }
    }
}

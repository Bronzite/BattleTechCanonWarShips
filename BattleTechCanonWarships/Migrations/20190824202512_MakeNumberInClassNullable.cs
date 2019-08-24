using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleTechCanonWarships.Migrations
{
    public partial class MakeNumberInClassNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberInClass",
                table: "ShipClasses",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberInClass",
                table: "ShipClasses",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

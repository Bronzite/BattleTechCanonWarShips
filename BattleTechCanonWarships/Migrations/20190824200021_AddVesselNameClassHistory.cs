using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleTechCanonWarships.Migrations
{
    public partial class AddVesselNameClassHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vessels",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PreviousVesselId",
                table: "Vessels",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipClassId",
                table: "Vessels",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_PreviousVesselId",
                table: "Vessels",
                column: "PreviousVesselId");

            migrationBuilder.CreateIndex(
                name: "IX_Vessels_ShipClassId",
                table: "Vessels",
                column: "ShipClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vessels_Vessels_PreviousVesselId",
                table: "Vessels",
                column: "PreviousVesselId",
                principalTable: "Vessels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vessels_ShipClasses_ShipClassId",
                table: "Vessels",
                column: "ShipClassId",
                principalTable: "ShipClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vessels_Vessels_PreviousVesselId",
                table: "Vessels");

            migrationBuilder.DropForeignKey(
                name: "FK_Vessels_ShipClasses_ShipClassId",
                table: "Vessels");

            migrationBuilder.DropIndex(
                name: "IX_Vessels_PreviousVesselId",
                table: "Vessels");

            migrationBuilder.DropIndex(
                name: "IX_Vessels_ShipClassId",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "PreviousVesselId",
                table: "Vessels");

            migrationBuilder.DropColumn(
                name: "ShipClassId",
                table: "Vessels");
        }
    }
}

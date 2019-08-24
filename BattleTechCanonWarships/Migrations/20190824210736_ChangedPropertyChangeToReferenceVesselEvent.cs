using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleTechCanonWarships.Migrations
{
    public partial class ChangedPropertyChangeToReferenceVesselEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyChange_Event_EventId",
                table: "PropertyChange");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyChange_VesselEvent_VesselEventId",
                table: "PropertyChange");

            migrationBuilder.DropIndex(
                name: "IX_PropertyChange_EventId",
                table: "PropertyChange");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "PropertyChange");

            migrationBuilder.AlterColumn<Guid>(
                name: "VesselEventId",
                table: "PropertyChange",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyChange_VesselEvent_VesselEventId",
                table: "PropertyChange",
                column: "VesselEventId",
                principalTable: "VesselEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyChange_VesselEvent_VesselEventId",
                table: "PropertyChange");

            migrationBuilder.AlterColumn<Guid>(
                name: "VesselEventId",
                table: "PropertyChange",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "PropertyChange",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PropertyChange_EventId",
                table: "PropertyChange",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyChange_Event_EventId",
                table: "PropertyChange",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyChange_VesselEvent_VesselEventId",
                table: "PropertyChange",
                column: "VesselEventId",
                principalTable: "VesselEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

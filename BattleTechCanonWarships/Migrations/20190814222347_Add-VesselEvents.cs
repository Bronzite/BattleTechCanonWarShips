using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleTechCanonWarships.Migrations
{
    public partial class AddVesselEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    X = table.Column<int>(nullable: true),
                    Y = table.Column<int>(nullable: true),
                    ParentLocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Location_ParentLocationId",
                        column: x => x.ParentLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SourceReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SourceId = table.Column<Guid>(nullable: false),
                    ReviewDate = table.Column<DateTime>(nullable: false),
                    StartPage = table.Column<int>(nullable: false),
                    EndPage = table.Column<int>(nullable: false),
                    Reviewer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SourceReview_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VesselEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VesselId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VesselEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VesselEvent_Vessels_VesselId",
                        column: x => x.VesselId,
                        principalTable: "Vessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyChange",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    PropertyId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    VesselEventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyChange_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyChange_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyChange_VesselEvent_VesselEventId",
                        column: x => x.VesselEventId,
                        principalTable: "VesselEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    URLCapture = table.Column<DateTime>(nullable: true),
                    SourceId = table.Column<Guid>(nullable: true),
                    Quote = table.Column<string>(nullable: true),
                    CreateBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ValidatedBy = table.Column<string>(nullable: true),
                    ValidatedOn = table.Column<DateTime>(nullable: true),
                    VesselEventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reference_Sources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reference_VesselEvent_VesselEventId",
                        column: x => x.VesselEventId,
                        principalTable: "VesselEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_LocationId",
                table: "Event",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ParentLocationId",
                table: "Location",
                column: "ParentLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyChange_EventId",
                table: "PropertyChange",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyChange_PropertyId",
                table: "PropertyChange",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyChange_VesselEventId",
                table: "PropertyChange",
                column: "VesselEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_SourceId",
                table: "Reference",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_VesselEventId",
                table: "Reference",
                column: "VesselEventId");

            migrationBuilder.CreateIndex(
                name: "IX_SourceReview_SourceId",
                table: "SourceReview",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_VesselEvent_EventId",
                table: "VesselEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_VesselEvent_VesselId",
                table: "VesselEvent",
                column: "VesselId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Location_LocationId",
                table: "Event");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "PropertyChange");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropTable(
                name: "SourceReview");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "VesselEvent");

            migrationBuilder.DropIndex(
                name: "IX_Event_LocationId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Event");
        }
    }
}

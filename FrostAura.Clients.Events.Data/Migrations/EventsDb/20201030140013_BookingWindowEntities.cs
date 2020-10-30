using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrostAura.Clients.Events.Data.Migrations.EventsDb
{
    public partial class BookingWindowEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingWindows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    ApplyTagsInclusively = table.Column<bool>(nullable: false),
                    HoursInAdvanceBookingsAllowed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingWindows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingWindowTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    TagId = table.Column<int>(nullable: false),
                    BookingWindowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingWindowTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingWindowTags_BookingWindows_BookingWindowId",
                        column: x => x.BookingWindowId,
                        principalTable: "BookingWindows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BookingWindowTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpaceBookingWindows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    SpaceId = table.Column<int>(nullable: false),
                    BookingWindowId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceBookingWindows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaceBookingWindows_BookingWindows_BookingWindowId",
                        column: x => x.BookingWindowId,
                        principalTable: "BookingWindows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpaceBookingWindows_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingWindowTags_BookingWindowId",
                table: "BookingWindowTags",
                column: "BookingWindowId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingWindowTags_TagId",
                table: "BookingWindowTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceBookingWindows_BookingWindowId",
                table: "SpaceBookingWindows",
                column: "BookingWindowId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceBookingWindows_SpaceId",
                table: "SpaceBookingWindows",
                column: "SpaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingWindowTags");

            migrationBuilder.DropTable(
                name: "SpaceBookingWindows");

            migrationBuilder.DropTable(
                name: "BookingWindows");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrostAura.Clients.Events.Data.Migrations.EventsDb
{
    public partial class SpaceDayPeriodTagEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpacesVisibleToTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    SpaceId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpacesVisibleToTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpacesVisibleToTags_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpacesVisibleToTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PeriodDays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    DayId = table.Column<int>(nullable: false),
                    PeriodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodDays_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PeriodDays_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpaceAvailability",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    SpaceId = table.Column<int>(nullable: false),
                    PeriodId = table.Column<int>(nullable: false),
                    DayId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaceAvailability_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpaceAvailability_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpaceAvailability_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDays_DayId",
                table: "PeriodDays",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodDays_PeriodId",
                table: "PeriodDays",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceAvailability_DayId",
                table: "SpaceAvailability",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceAvailability_PeriodId",
                table: "SpaceAvailability",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceAvailability_SpaceId",
                table: "SpaceAvailability",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpacesVisibleToTags_SpaceId",
                table: "SpacesVisibleToTags",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpacesVisibleToTags_TagId",
                table: "SpacesVisibleToTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeriodDays");

            migrationBuilder.DropTable(
                name: "SpaceAvailability");

            migrationBuilder.DropTable(
                name: "SpacesVisibleToTags");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "Periods");
        }
    }
}

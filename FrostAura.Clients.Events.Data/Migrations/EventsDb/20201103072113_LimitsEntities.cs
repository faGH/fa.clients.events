using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrostAura.Clients.Events.Data.Migrations.EventsDb
{
    public partial class LimitsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Limits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ApplyTagsInclusively = table.Column<bool>(nullable: false),
                    DurationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Limits_Durations_DurationId",
                        column: x => x.DurationId,
                        principalTable: "Durations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LimitTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    LimitId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimitTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LimitTags_Limits_LimitId",
                        column: x => x.LimitId,
                        principalTable: "Limits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LimitTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpaceLimits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    SpaceId = table.Column<int>(nullable: false),
                    LimitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceLimits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaceLimits_Limits_LimitId",
                        column: x => x.LimitId,
                        principalTable: "Limits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpaceLimits_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Limits_DurationId",
                table: "Limits",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_LimitTags_LimitId",
                table: "LimitTags",
                column: "LimitId");

            migrationBuilder.CreateIndex(
                name: "IX_LimitTags_TagId",
                table: "LimitTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceLimits_LimitId",
                table: "SpaceLimits",
                column: "LimitId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceLimits_SpaceId",
                table: "SpaceLimits",
                column: "SpaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LimitTags");

            migrationBuilder.DropTable(
                name: "SpaceLimits");

            migrationBuilder.DropTable(
                name: "Limits");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrostAura.Clients.Events.Data.Migrations.EventsDb
{
    public partial class LogicalAndConditionEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conditions",
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
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ControlTypes",
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
                    table.PrimaryKey("PK_ControlTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Durations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Minutes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
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
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrLogic",
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
                    table.PrimaryKey("PK_OrLogic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    PeriodId = table.Column<int>(nullable: false),
                    ConditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionPeriods_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConditionPeriods_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SpaceConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    SpaceId = table.Column<int>(nullable: false),
                    ConditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpaceConditions_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SpaceConditions_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "LogicKeys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ControlTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogicKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogicKeys_ControlTypes_ControlTypeId",
                        column: x => x.ControlTypeId,
                        principalTable: "ControlTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrLogicConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    OrLogicId = table.Column<int>(nullable: false),
                    ConditionId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrLogicConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrLogicConditions_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrLogicConditions_OrLogic_OrLogicId",
                        column: x => x.OrLogicId,
                        principalTable: "OrLogic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IfLogic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DurationId = table.Column<int>(nullable: true),
                    OperatorId = table.Column<int>(nullable: false),
                    LogicKeyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IfLogic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IfLogic_Durations_DurationId",
                        column: x => x.DurationId,
                        principalTable: "Durations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IfLogic_LogicKeys_LogicKeyId",
                        column: x => x.LogicKeyId,
                        principalTable: "LogicKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IfLogic_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "IfLogicTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    IfLogicId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IfLogicTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IfLogicTags_IfLogic_IfLogicId",
                        column: x => x.IfLogicId,
                        principalTable: "IfLogic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IfLogicTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrLogicIfLogicGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    OrLogicId = table.Column<int>(nullable: false),
                    IfLogicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrLogicIfLogicGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrLogicIfLogicGroups_IfLogic_IfLogicId",
                        column: x => x.IfLogicId,
                        principalTable: "IfLogic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrLogicIfLogicGroups_OrLogic_OrLogicId",
                        column: x => x.OrLogicId,
                        principalTable: "OrLogic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConditionPeriods_ConditionId",
                table: "ConditionPeriods",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionPeriods_PeriodId",
                table: "ConditionPeriods",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_IfLogic_DurationId",
                table: "IfLogic",
                column: "DurationId");

            migrationBuilder.CreateIndex(
                name: "IX_IfLogic_LogicKeyId",
                table: "IfLogic",
                column: "LogicKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_IfLogic_OperatorId",
                table: "IfLogic",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_IfLogicTags_IfLogicId",
                table: "IfLogicTags",
                column: "IfLogicId");

            migrationBuilder.CreateIndex(
                name: "IX_IfLogicTags_TagId",
                table: "IfLogicTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_LogicKeys_ControlTypeId",
                table: "LogicKeys",
                column: "ControlTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrLogicConditions_ConditionId",
                table: "OrLogicConditions",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrLogicConditions_OrLogicId",
                table: "OrLogicConditions",
                column: "OrLogicId");

            migrationBuilder.CreateIndex(
                name: "IX_OrLogicIfLogicGroups_IfLogicId",
                table: "OrLogicIfLogicGroups",
                column: "IfLogicId");

            migrationBuilder.CreateIndex(
                name: "IX_OrLogicIfLogicGroups_OrLogicId",
                table: "OrLogicIfLogicGroups",
                column: "OrLogicId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceConditions_ConditionId",
                table: "SpaceConditions",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceConditions_SpaceId",
                table: "SpaceConditions",
                column: "SpaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConditionPeriods");

            migrationBuilder.DropTable(
                name: "IfLogicTags");

            migrationBuilder.DropTable(
                name: "OrLogicConditions");

            migrationBuilder.DropTable(
                name: "OrLogicIfLogicGroups");

            migrationBuilder.DropTable(
                name: "SpaceConditions");

            migrationBuilder.DropTable(
                name: "IfLogic");

            migrationBuilder.DropTable(
                name: "OrLogic");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Durations");

            migrationBuilder.DropTable(
                name: "LogicKeys");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "ControlTypes");
        }
    }
}

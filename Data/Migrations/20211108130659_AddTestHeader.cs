using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddTestHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorID = table.Column<int>(nullable: false),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    UpdatedUser = table.Column<int>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TestType = table.Column<int>(nullable: false),
                    TitleId = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: true),
                    EntityType = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestHeaders_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestHeaders_Lookups_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestHeaders_ProjectId",
                table: "TestHeaders",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TestHeaders_TitleId",
                table: "TestHeaders",
                column: "TitleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestHeaders");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddProjectUserRelTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectUsersRelations",
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
                    UserId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUsersRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectUsersRelations_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUsersRelations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsersRelations_ProjectId",
                table: "ProjectUsersRelations",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsersRelations_UserId",
                table: "ProjectUsersRelations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectUsersRelations");
        }
    }
}

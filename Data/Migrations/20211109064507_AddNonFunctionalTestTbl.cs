using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddNonFunctionalTestTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeReviews",
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
                    TestHeaderId = table.Column<int>(nullable: false),
                    AllCountRow = table.Column<int>(nullable: false),
                    MatchGroups = table.Column<int>(nullable: false),
                    AccurateMatch = table.Column<int>(nullable: false),
                    HighMatch = table.Column<int>(nullable: false),
                    NormalMatch = table.Column<int>(nullable: false),
                    PoorMatch = table.Column<int>(nullable: false),
                    Offers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeReviews_TestHeaders_TestHeaderId",
                        column: x => x.TestHeaderId,
                        principalTable: "TestHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocReviews",
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
                    TestHeaderId = table.Column<int>(nullable: false),
                    DocReviewTitle = table.Column<int>(nullable: false),
                    DocReviewAnswer = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocReviews_TestHeaders_TestHeaderId",
                        column: x => x.TestHeaderId,
                        principalTable: "TestHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoadAndStersses",
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
                    TestHeaderId = table.Column<int>(nullable: false),
                    TotalRequest = table.Column<int>(nullable: false),
                    SuccessRequest = table.Column<int>(nullable: false),
                    FailRequest = table.Column<int>(nullable: false),
                    AveTime = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadAndStersses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoadAndStersses_TestHeaders_TestHeaderId",
                        column: x => x.TestHeaderId,
                        principalTable: "TestHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CodeReviewDetails",
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
                    CodeReviewId = table.Column<int>(nullable: false),
                    DetailType = table.Column<int>(nullable: false),
                    IndicatorId = table.Column<int>(nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeReviewDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeReviewDetails_CodeReviews_CodeReviewId",
                        column: x => x.CodeReviewId,
                        principalTable: "CodeReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CodeReviewDetails_Lookups_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Lookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeReviewDetails_CodeReviewId",
                table: "CodeReviewDetails",
                column: "CodeReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeReviewDetails_IndicatorId",
                table: "CodeReviewDetails",
                column: "IndicatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CodeReviews_TestHeaderId",
                table: "CodeReviews",
                column: "TestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_DocReviews_TestHeaderId",
                table: "DocReviews",
                column: "TestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_LoadAndStersses_TestHeaderId",
                table: "LoadAndStersses",
                column: "TestHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeReviewDetails");

            migrationBuilder.DropTable(
                name: "DocReviews");

            migrationBuilder.DropTable(
                name: "LoadAndStersses");

            migrationBuilder.DropTable(
                name: "CodeReviews");
        }
    }
}

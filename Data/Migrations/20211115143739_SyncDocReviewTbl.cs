using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SyncDocReviewTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discription",
                table: "DocReviews");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DocReviews",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "DocReviews");

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "DocReviews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

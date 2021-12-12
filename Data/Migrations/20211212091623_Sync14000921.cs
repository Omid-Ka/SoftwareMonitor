using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Sync14000921 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "Attachment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Attachment");
        }
    }
}

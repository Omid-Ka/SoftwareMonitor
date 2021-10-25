using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SyncDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Lookups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Lookups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Lookups");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Lookups");
        }
    }
}

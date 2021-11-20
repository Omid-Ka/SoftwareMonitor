using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddafewColumnInLOadAndStressTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Deviation",
                table: "LoadAndStersses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Throughput",
                table: "LoadAndStersses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deviation",
                table: "LoadAndStersses");

            migrationBuilder.DropColumn(
                name: "Throughput",
                table: "LoadAndStersses");
        }
    }
}

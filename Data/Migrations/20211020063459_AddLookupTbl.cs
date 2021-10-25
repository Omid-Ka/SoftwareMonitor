using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddLookupTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatorID = table.Column<int>(nullable: false),
                    DateInserted = table.Column<DateTime>(nullable: false),
                    UpdatedUser = table.Column<int>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Information = table.Column<string>(nullable: true),
                    ReferenceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lookups");
        }
    }
}

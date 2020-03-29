using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceControl.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpentCategoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpentCategoryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpentItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpentItems_SpentCategoryItems_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SpentCategoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpentItems_CategoryId",
                table: "SpentItems",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpentItems");

            migrationBuilder.DropTable(
                name: "SpentCategoryItems");
        }
    }
}

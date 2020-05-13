using Microsoft.EntityFrameworkCore.Migrations;
using WebApi.Models;

namespace WebApi.Migrations
{
    public partial class CompanyAsJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tree",
                table: "Posts");

            migrationBuilder.AddColumn<Company>(
                name: "Companies",
                table: "Posts",
                type: "jsonb",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Companies",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Tree",
                table: "Posts",
                type: "jsonb",
                nullable: true);
        }
    }
}

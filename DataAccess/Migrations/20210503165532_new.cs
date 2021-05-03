using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

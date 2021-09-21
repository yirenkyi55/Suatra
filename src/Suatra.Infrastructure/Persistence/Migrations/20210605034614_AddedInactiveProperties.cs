using Microsoft.EntityFrameworkCore.Migrations;

namespace Suatra.Infrastructure.Persistence.Migrations
{
    public partial class AddedInactiveProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInactive",
                table: "Topics",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInactive",
                table: "SectionContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInactive",
                table: "CourseSections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "CourseAuthors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInActive",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInactive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInactive",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "IsInactive",
                table: "SectionContents");

            migrationBuilder.DropColumn(
                name: "IsInactive",
                table: "CourseSections");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "CourseAuthors");

            migrationBuilder.DropColumn(
                name: "IsInActive",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsInactive",
                table: "AspNetUsers");
        }
    }
}

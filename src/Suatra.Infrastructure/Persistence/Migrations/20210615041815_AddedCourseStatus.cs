using Microsoft.EntityFrameworkCore.Migrations;

namespace Suatra.Infrastructure.Persistence.Migrations
{
    public partial class AddedCourseStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseStatus",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseStatus",
                table: "Courses");
        }
    }
}

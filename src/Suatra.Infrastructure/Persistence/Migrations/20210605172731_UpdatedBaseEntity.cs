using Microsoft.EntityFrameworkCore.Migrations;

namespace Suatra.Infrastructure.Persistence.Migrations
{
    public partial class UpdatedBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInactive",
                table: "Topics",
                newName: "IsInActive");

            migrationBuilder.RenameColumn(
                name: "IsInactive",
                table: "SectionContents",
                newName: "IsInActive");

            migrationBuilder.RenameColumn(
                name: "IsInactive",
                table: "CourseSections",
                newName: "IsInActive");

            migrationBuilder.RenameColumn(
                name: "IsInactive",
                table: "AspNetUsers",
                newName: "IsInActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInActive",
                table: "Topics",
                newName: "IsInactive");

            migrationBuilder.RenameColumn(
                name: "IsInActive",
                table: "SectionContents",
                newName: "IsInactive");

            migrationBuilder.RenameColumn(
                name: "IsInActive",
                table: "CourseSections",
                newName: "IsInactive");

            migrationBuilder.RenameColumn(
                name: "IsInActive",
                table: "AspNetUsers",
                newName: "IsInactive");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Suatra.Infrastructure.Persistence.Migrations
{
    public partial class UpdatedCourseToIncludeAnAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAuthors");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_AuthorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CourseAuthors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsInActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAuthors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseAuthors_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseAuthors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAuthors_CourseId",
                table: "CourseAuthors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAuthors_UserId",
                table: "CourseAuthors",
                column: "UserId");
        }
    }
}

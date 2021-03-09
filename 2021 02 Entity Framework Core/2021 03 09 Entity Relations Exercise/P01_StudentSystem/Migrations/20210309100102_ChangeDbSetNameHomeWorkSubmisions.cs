using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class ChangeDbSetNameHomeWorkSubmisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Courses_CourseId",
                table: "Homeworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks");

            migrationBuilder.RenameTable(
                name: "Homeworks",
                newName: "HomeworkSubmission");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_StudentId",
                table: "HomeworkSubmission",
                newName: "IX_HomeworkSubmission_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Homeworks_CourseId",
                table: "HomeworkSubmission",
                newName: "IX_HomeworkSubmission_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeworkSubmission",
                table: "HomeworkSubmission",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmission_Courses_CourseId",
                table: "HomeworkSubmission",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeworkSubmission_Students_StudentId",
                table: "HomeworkSubmission",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmission_Courses_CourseId",
                table: "HomeworkSubmission");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeworkSubmission_Students_StudentId",
                table: "HomeworkSubmission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeworkSubmission",
                table: "HomeworkSubmission");

            migrationBuilder.RenameTable(
                name: "HomeworkSubmission",
                newName: "Homeworks");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworkSubmission_StudentId",
                table: "Homeworks",
                newName: "IX_Homeworks_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_HomeworkSubmission_CourseId",
                table: "Homeworks",
                newName: "IX_Homeworks_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Homeworks",
                table: "Homeworks",
                column: "HomeworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Courses_CourseId",
                table: "Homeworks",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Students_StudentId",
                table: "Homeworks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

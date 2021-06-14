using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationX.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AcademicRankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AcademicRanks_AcademicRankId",
                        column: x => x.AcademicRankId,
                        principalTable: "AcademicRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DateEnrolled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourse",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourse", x => new { x.TeacherId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentEnrollmentId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<byte>(type: "tinyint", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGrades", x => x.Id);
                    table.CheckConstraint("CK_StudentGrade_Grade", "[Grade] BETWEEN 1 AND 100");
                    table.ForeignKey(
                        name: "FK_StudentGrades_StudentEnrollments_StudentEnrollmentId",
                        column: x => x.StudentEnrollmentId,
                        principalTable: "StudentEnrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicRanks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Professor" },
                    { 2, "Associate professor" },
                    { 3, "Assistant Professor" },
                    { 4, "Lecturer" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Math" },
                    { 2, "Physics" },
                    { 3, "Acting classes" },
                    { 4, "Paleontology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 4, new DateTime(1993, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgi", "Findulov" },
                    { 5, new DateTime(1990, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Smith" },
                    { 6, new DateTime(1999, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark", "Johnson" },
                    { 7, new DateTime(1997, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlotte", "Williams" },
                    { 1, new DateTime(1967, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joey", "Tribbiani" },
                    { 2, new DateTime(1967, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ross", "Geller" },
                    { 3, new DateTime(1980, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evelyn", "Harper" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                column: "Id",
                values: new object[]
                {
                    4,
                    5,
                    6,
                    7
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AcademicRankId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "Id", "CourseId", "DateEnrolled", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 6, 13, 23, 25, 34, 20, DateTimeKind.Utc).AddTicks(4647), 4 },
                    { 2, 2, new DateTime(2021, 3, 15, 23, 25, 34, 20, DateTimeKind.Utc).AddTicks(6645), 4 },
                    { 3, 3, new DateTime(2021, 2, 13, 23, 25, 34, 20, DateTimeKind.Utc).AddTicks(6710), 5 },
                    { 4, 4, new DateTime(2021, 3, 18, 23, 25, 34, 20, DateTimeKind.Utc).AddTicks(6714), 6 },
                    { 5, 3, new DateTime(2020, 5, 6, 23, 25, 34, 20, DateTimeKind.Utc).AddTicks(6715), 7 }
                });

            migrationBuilder.InsertData(
                table: "TeacherCourse",
                columns: new[] { "CourseId", "TeacherId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "StudentGrades",
                columns: new[] { "Id", "DateCreated", "Grade", "StudentEnrollmentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 13, 23, 25, 34, 22, DateTimeKind.Utc).AddTicks(1345), (byte)31, 1 },
                    { 2, new DateTime(2021, 6, 13, 23, 25, 34, 22, DateTimeKind.Utc).AddTicks(1747), (byte)4, 1 },
                    { 3, new DateTime(2021, 6, 13, 23, 25, 34, 22, DateTimeKind.Utc).AddTicks(1764), (byte)63, 2 },
                    { 4, new DateTime(2021, 6, 13, 23, 25, 34, 22, DateTimeKind.Utc).AddTicks(1781), (byte)6, 2 },
                    { 6, new DateTime(2021, 6, 13, 23, 25, 34, 22, DateTimeKind.Utc).AddTicks(1815), (byte)20, 3 },
                    { 5, new DateTime(2021, 6, 13, 23, 25, 34, 22, DateTimeKind.Utc).AddTicks(1797), (byte)94, 4 },
                    { 7, new DateTime(2021, 6, 13, 23, 25, 34, 22, DateTimeKind.Utc).AddTicks(1832), (byte)98, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_CourseId",
                table: "StudentEnrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_StudentId",
                table: "StudentEnrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGrades_StudentEnrollmentId",
                table: "StudentGrades",
                column: "StudentEnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourse_CourseId",
                table: "TeacherCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_AcademicRankId",
                table: "Teachers",
                column: "AcademicRankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentGrades");

            migrationBuilder.DropTable(
                name: "TeacherCourse");

            migrationBuilder.DropTable(
                name: "StudentEnrollments");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AcademicRanks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

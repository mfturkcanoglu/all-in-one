using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlIInOne.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lecturers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lecturers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    studentidentity = table.Column<string>(name: "student_identity", type: "text", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    passwordhash = table.Column<byte[]>(name: "password_hash", type: "bytea", nullable: false),
                    passwordsalt = table.Column<byte[]>(name: "password_salt", type: "bytea", nullable: false),
                    verificationtoken = table.Column<string>(name: "verification_token", type: "text", nullable: true),
                    verifiedat = table.Column<DateTime>(name: "verified_at", type: "timestamp with time zone", nullable: true),
                    passwordresettoken = table.Column<string>(name: "password_reset_token", type: "text", nullable: true),
                    resettokenexpires = table.Column<DateTime>(name: "reset_token_expires", type: "timestamp with time zone", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: false),
                    branch = table.Column<int>(type: "integer", nullable: false),
                    lecturerid = table.Column<Guid>(name: "lecturer_id", type: "uuid", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lessons", x => x.id);
                    table.ForeignKey(
                        name: "fk_lessons_lecturers_lecturer_id",
                        column: x => x.lecturerid,
                        principalTable: "lecturers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lesson_students",
                columns: table => new
                {
                    studentid = table.Column<Guid>(name: "student_id", type: "uuid", nullable: false),
                    lessonid = table.Column<Guid>(name: "lesson_id", type: "uuid", nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
                    updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "timestamp with time zone", nullable: true),
                    deleted = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lesson_students", x => new { x.studentid, x.lessonid });
                    table.ForeignKey(
                        name: "fk_lesson_students_lessons_lesson_id",
                        column: x => x.lessonid,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lesson_students_students_student_id",
                        column: x => x.studentid,
                        principalTable: "students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_lesson_students_lesson_id",
                table: "lesson_students",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "ix_lessons_lecturer_id",
                table: "lessons",
                column: "lecturer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lesson_students");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "lecturers");
        }
    }
}

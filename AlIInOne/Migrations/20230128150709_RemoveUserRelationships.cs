using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlIInOne.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_users_lecturers_lecturer_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_users_students_student_id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "ix_asp_net_users_lecturer_id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "ix_asp_net_users_student_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lecturer_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "student_id",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "lecturer_id",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "student_id",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_lecturer_id",
                table: "AspNetUsers",
                column: "lecturer_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_student_id",
                table: "AspNetUsers",
                column: "student_id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_users_lecturers_lecturer_id",
                table: "AspNetUsers",
                column: "lecturer_id",
                principalTable: "lecturers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_users_students_student_id",
                table: "AspNetUsers",
                column: "student_id",
                principalTable: "students",
                principalColumn: "id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace varsity.Migrations
{
    /// <inheritdoc />
    public partial class M202306151900 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "ARFPersons");

            migrationBuilder.DropColumn(
                name: "LecturerNumber",
                table: "ARFPersons");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "ARFPersons");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "ARFPersons");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcademicYear",
                table: "Modules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicYear",
                table: "Modules");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "ARFPersons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LecturerNumber",
                table: "ARFPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "ARFPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentNumber",
                table: "ARFPersons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace varsity.Migrations
{
    /// <inheritdoc />
    public partial class M202306051937 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ARFPersons_Courses_LastNameId",
                table: "ARFPersons");

            migrationBuilder.DropIndex(
                name: "IX_ARFPersons_LastNameId",
                table: "ARFPersons");

            migrationBuilder.DropColumn(
                name: "LastNameId",
                table: "ARFPersons");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ARFPersons",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ARFPersons");

            migrationBuilder.AddColumn<Guid>(
                name: "LastNameId",
                table: "ARFPersons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ARFPersons_LastNameId",
                table: "ARFPersons",
                column: "LastNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ARFPersons_Courses_LastNameId",
                table: "ARFPersons",
                column: "LastNameId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}

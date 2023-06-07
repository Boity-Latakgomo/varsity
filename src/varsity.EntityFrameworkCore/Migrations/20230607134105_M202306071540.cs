using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace varsity.Migrations
{
    /// <inheritdoc />
    public partial class M202306071540 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_ARFPersons_PersonId",
                table: "BookMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Answers_AnswerId",
                table: "BookMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Ratings_VoteTypeId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_VoteTypeId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "VoteTypeId",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "VoteType",
                table: "Ratings",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "BookMarks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AnswerId",
                table: "BookMarks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_ARFPersons_PersonId",
                table: "BookMarks",
                column: "PersonId",
                principalTable: "ARFPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Answers_AnswerId",
                table: "BookMarks",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_ARFPersons_PersonId",
                table: "BookMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Answers_AnswerId",
                table: "BookMarks");

            migrationBuilder.DropColumn(
                name: "VoteType",
                table: "Ratings");

            migrationBuilder.AddColumn<Guid>(
                name: "VoteTypeId",
                table: "Ratings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "BookMarks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AnswerId",
                table: "BookMarks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_VoteTypeId",
                table: "Ratings",
                column: "VoteTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_ARFPersons_PersonId",
                table: "BookMarks",
                column: "PersonId",
                principalTable: "ARFPersons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Answers_AnswerId",
                table: "BookMarks",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Ratings_VoteTypeId",
                table: "Ratings",
                column: "VoteTypeId",
                principalTable: "Ratings",
                principalColumn: "Id");
        }
    }
}

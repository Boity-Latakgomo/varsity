using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace varsity.Migrations
{
    /// <inheritdoc />
    public partial class M202306081717 : Migration
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
                name: "FK_BookMarks_Questions_QuestionId",
                table: "BookMarks");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "BookMarks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                name: "FK_BookMarks_Questions_QuestionId",
                table: "BookMarks",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
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

            migrationBuilder.DropForeignKey(
                name: "FK_BookMarks_Questions_QuestionId",
                table: "BookMarks");

            migrationBuilder.AlterColumn<Guid>(
                name: "QuestionId",
                table: "BookMarks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookMarks_Questions_QuestionId",
                table: "BookMarks",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

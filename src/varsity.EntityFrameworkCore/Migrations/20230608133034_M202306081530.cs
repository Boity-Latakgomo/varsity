using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace varsity.Migrations
{
    /// <inheritdoc />
    public partial class M202306081530 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<Guid>(
            //    name: "PersonId",
            //    table: "Answers",
            //    type: "uniqueidentifier",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Answers_PersonId",
            //    table: "Answers",
            //    column: "PersonId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Answers_ARFPersons_PersonId",
            //    table: "Answers",
            //    column: "PersonId",
            //    principalTable: "ARFPersons",
            //    principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Answers_ARFPersons_PersonId",
            //    table: "Answers");

            //migrationBuilder.DropIndex(
            //    name: "IX_Answers_PersonId",
            //    table: "Answers");

            //migrationBuilder.DropColumn(
            //    name: "PersonId",
            //    table: "Answers");
        }
    }
}

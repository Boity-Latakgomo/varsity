//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace varsity.Migrations
//{
//    /// <inheritdoc />
//    public partial class M202306081522 : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Answers_ARFPersons_PersonId",
//                table: "Answers");

//            migrationBuilder.DropIndex(
//                name: "IX_Answers_PersonId",
//                table: "Answers");

//            migrationBuilder.DropColumn(
//                name: "PersonId",
//                table: "Answers");

//            migrationBuilder.CreateTable(
//                name: "AnswerQs",
//                columns: table => new
//                {
//                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
//                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
//                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
//                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
//                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
//                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
//                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_AnswerQs", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_AnswerQs_ARFPersons_PersonId",
//                        column: x => x.PersonId,
//                        principalTable: "ARFPersons",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_AnswerQs_Questions_QuestionId",
//                        column: x => x.QuestionId,
//                        principalTable: "Questions",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_AnswerQs_PersonId",
//                table: "AnswerQs",
//                column: "PersonId");

//            migrationBuilder.CreateIndex(
//                name: "IX_AnswerQs_QuestionId",
//                table: "AnswerQs",
//                column: "QuestionId");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "AnswerQs");

//            migrationBuilder.AddColumn<Guid>(
//                name: "PersonId",
//                table: "Answers",
//                type: "uniqueidentifier",
//                nullable: true);

//            migrationBuilder.CreateIndex(
//                name: "IX_Answers_PersonId",
//                table: "Answers",
//                column: "PersonId");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Answers_ARFPersons_PersonId",
//                table: "Answers",
//                column: "PersonId",
//                principalTable: "ARFPersons",
//                principalColumn: "Id");
//        }
//    }
//}

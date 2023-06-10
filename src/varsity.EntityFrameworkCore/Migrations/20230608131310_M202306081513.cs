﻿//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//#nullable disable

//namespace varsity.Migrations
//{
//    /// <inheritdoc />
//    public partial class M202306081513 : Migration
//    {
//        /// <inheritdoc />
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Answers_ARFPersons_PersonId",
//                table: "Answers");

//            migrationBuilder.AlterColumn<Guid>(
//                name: "PersonId",
//                table: "Answers",
//                type: "uniqueidentifier",
//                nullable: true,
//                oldClrType: typeof(Guid),
//                oldType: "uniqueidentifier");

//            migrationBuilder.AddForeignKey(
//                name: "FK_Answers_ARFPersons_PersonId",
//                table: "Answers",
//                column: "PersonId",
//                principalTable: "ARFPersons",
//                principalColumn: "Id");
//        }

//        /// <inheritdoc />
//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropForeignKey(
//                name: "FK_Answers_ARFPersons_PersonId",
//                table: "Answers");

//            migrationBuilder.AlterColumn<Guid>(
//                name: "PersonId",
//                table: "Answers",
//                type: "uniqueidentifier",
//                nullable: false,
//                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
//                oldClrType: typeof(Guid),
//                oldType: "uniqueidentifier",
//                oldNullable: true);

//            migrationBuilder.AddForeignKey(
//                name: "FK_Answers_ARFPersons_PersonId",
//                table: "Answers",
//                column: "PersonId",
//                principalTable: "ARFPersons",
//                principalColumn: "Id",
//                onDelete: ReferentialAction.Cascade);
//        }
//    }
//}
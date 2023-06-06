using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace varsity.Migrations
{
    /// <inheritdoc />
    public partial class M202306062257 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturersModules_ARFPersons_LecturerId",
                table: "LecturersModules");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturersModules_ARFPersons_ModuleId",
                table: "LecturersModules");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuleId",
                table: "LecturersModules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "LecturerId",
                table: "LecturersModules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ModuleStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleStudents_ARFPersons_StudentId",
                        column: x => x.StudentId,
                        principalTable: "ARFPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuleStudents_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStudents_ModuleId",
                table: "ModuleStudents",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuleStudents_StudentId",
                table: "ModuleStudents",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturersModules_ARFPersons_LecturerId",
                table: "LecturersModules",
                column: "LecturerId",
                principalTable: "ARFPersons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LecturersModules_Modules_ModuleId",
                table: "LecturersModules",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturersModules_ARFPersons_LecturerId",
                table: "LecturersModules");

            migrationBuilder.DropForeignKey(
                name: "FK_LecturersModules_Modules_ModuleId",
                table: "LecturersModules");

            migrationBuilder.DropTable(
                name: "ModuleStudents");

            migrationBuilder.AlterColumn<Guid>(
                name: "ModuleId",
                table: "LecturersModules",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "LecturerId",
                table: "LecturersModules",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturersModules_ARFPersons_LecturerId",
                table: "LecturersModules",
                column: "LecturerId",
                principalTable: "ARFPersons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturersModules_ARFPersons_ModuleId",
                table: "LecturersModules",
                column: "ModuleId",
                principalTable: "ARFPersons",
                principalColumn: "Id");
        }
    }
}

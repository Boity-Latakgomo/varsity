using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace varsity.Migrations
{
    /// <inheritdoc />
    public partial class M202306052155 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ARFPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ARFPersons",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ARFPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ARFPersons_UserId",
                table: "ARFPersons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ARFPersons_AbpUsers_UserId",
                table: "ARFPersons",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ARFPersons_AbpUsers_UserId",
                table: "ARFPersons");

            migrationBuilder.DropIndex(
                name: "IX_ARFPersons_UserId",
                table: "ARFPersons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "ARFPersons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ARFPersons");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ARFPersons");
        }
    }
}

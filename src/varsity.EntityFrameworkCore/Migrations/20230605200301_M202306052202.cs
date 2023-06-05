using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace varsity.Migrations
{
    /// <inheritdoc />
    public partial class M202306052202 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "ARFPersons",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "ARFPersons",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "CellPhoneNumber",
                table: "ARFPersons",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "ARFPersons",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ARFPersons",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ARFPersons",
                newName: "CellPhoneNumber");
        }
    }
}

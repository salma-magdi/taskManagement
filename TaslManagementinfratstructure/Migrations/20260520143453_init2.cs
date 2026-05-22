using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaslManagementinfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "projects",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Tasks",
                newName: "dueDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "projects",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "dueDate",
                table: "Tasks",
                newName: "CreateTime");
        }
    }
}

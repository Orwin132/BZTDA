using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NardSmena.Migrations
{
    /// <inheritdoc />
    public partial class Add_FIO_DepartmentAttributesRoleAssignmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "dbo",
                table: "RoleAssignmentViewModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FIO",
                schema: "dbo",
                table: "RoleAssignmentViewModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                schema: "dbo",
                table: "RoleAssignmentViewModels");

            migrationBuilder.DropColumn(
                name: "FIO",
                schema: "dbo",
                table: "RoleAssignmentViewModels");
        }
    }
}

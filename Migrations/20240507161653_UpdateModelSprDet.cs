using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NardSmena.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelSprDet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleAssignmentViewModels",
                schema: "dbo",
                table: "RoleAssignmentViewModels");

            migrationBuilder.RenameTable(
                name: "RoleAssignmentViewModels",
                schema: "dbo",
                newName: "RoleAssignments",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleAssignments",
                schema: "dbo",
                table: "RoleAssignments",
                column: "RoleAssignmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleAssignments",
                schema: "dbo",
                table: "RoleAssignments");

            migrationBuilder.RenameTable(
                name: "RoleAssignments",
                schema: "dbo",
                newName: "RoleAssignmentViewModels",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleAssignmentViewModels",
                schema: "dbo",
                table: "RoleAssignmentViewModels",
                column: "RoleAssignmentId");
        }
    }
}

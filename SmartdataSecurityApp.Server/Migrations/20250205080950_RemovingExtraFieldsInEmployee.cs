using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartdataSecurityApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class RemovingExtraFieldsInEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Roles_RoleId1",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_tenants_TenantId1",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RoleId1",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_TenantId1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TenantId1",
                table: "Employee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TenantId1",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "id",
                keyValue: 1000,
                columns: new[] { "RoleId1", "TenantId1" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId1",
                table: "Employee",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TenantId1",
                table: "Employee",
                column: "TenantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Roles_RoleId1",
                table: "Employee",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_tenants_TenantId1",
                table: "Employee",
                column: "TenantId1",
                principalTable: "tenants",
                principalColumn: "id");
        }
    }
}

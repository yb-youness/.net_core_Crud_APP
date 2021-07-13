using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMangmentSystem.Migrations
{
    public partial class addFK_key_Dep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentTypeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDepartment",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentTypeId",
                table: "Users",
                column: "DepartmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentTypeId",
                table: "Users",
                column: "DepartmentTypeId",
                principalTable: "Departments",
                principalColumn: "IdDepartment",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DepartmentTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdDepartment",
                table: "Users");
        }
    }
}

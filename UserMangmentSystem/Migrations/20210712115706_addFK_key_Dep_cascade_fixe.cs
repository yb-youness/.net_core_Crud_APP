using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMangmentSystem.Migrations
{
    public partial class addFK_key_Dep_cascade_fixe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentTypeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentTypeId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentTypeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentTypeId",
                table: "Users",
                column: "DepartmentTypeId",
                principalTable: "Departments",
                principalColumn: "IdDepartment",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

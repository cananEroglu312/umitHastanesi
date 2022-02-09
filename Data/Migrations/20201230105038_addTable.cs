using Microsoft.EntityFrameworkCore.Migrations;

namespace umitHastanesiWeb.Data.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Doctor_DoctorId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Department_DoctorId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Doctor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DepartmentId",
                table: "Doctor",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_DepartmentId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Doctor");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Department_DoctorId",
                table: "Department",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Doctor_DoctorId",
                table: "Department",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

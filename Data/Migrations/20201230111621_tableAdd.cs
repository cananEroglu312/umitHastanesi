using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace umitHastanesiWeb.Data.Migrations
{
    public partial class tableAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Department_DepartmentId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DepartmentId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Appointment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Doctor",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "DegreeId",
                table: "Doctor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Doctor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Appointment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DegreeId",
                table: "Doctor",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_LanguageId",
                table: "Doctor",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Doctor_DoctorId",
                table: "Appointment",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Degree_DegreeId",
                table: "Doctor",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Language_LanguageId",
                table: "Doctor",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Doctor_DoctorId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Degree_DegreeId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Language_LanguageId",
                table: "Doctor");

            migrationBuilder.DropTable(
                name: "Degree");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_DegreeId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_LanguageId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "DegreeId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Doctor",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DepartmentId",
                table: "Appointment",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Department_DepartmentId",
                table: "Appointment",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

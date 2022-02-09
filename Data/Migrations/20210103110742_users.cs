using Microsoft.EntityFrameworkCore.Migrations;

namespace umitHastanesiWeb.Data.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId1",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_UserId1",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId",
                table: "Appointment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_UserId",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Appointment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_UserId1",
                table: "Appointment",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AspNetUsers_UserId1",
                table: "Appointment",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

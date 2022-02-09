using Microsoft.EntityFrameworkCore.Migrations;

namespace umitHastanesiWeb.Data.Migrations
{
    public partial class admin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Department");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

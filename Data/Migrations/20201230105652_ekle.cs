using Microsoft.EntityFrameworkCore.Migrations;

namespace umitHastanesiWeb.Data.Migrations
{
    public partial class ekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Doctor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctor");
        }
    }
}

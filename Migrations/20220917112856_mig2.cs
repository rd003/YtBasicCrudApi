using Microsoft.EntityFrameworkCore.Migrations;

namespace YtBasicCrudApi.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aget",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Student",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "Aget",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace NaturalDisasterDatabaseWebsite.Migrations
{
    public partial class InititalCreate03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "wz_img",
                table: "science_essay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "wz_img",
                table: "science_essay",
                nullable: true);
        }
    }
}

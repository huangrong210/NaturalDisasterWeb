using Microsoft.EntityFrameworkCore.Migrations;

namespace NaturalDisasterDatabaseWebsite.Migrations
{
    public partial class sex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "sex",
                table: "users",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sex",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}

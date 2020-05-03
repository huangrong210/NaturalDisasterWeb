using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NaturalDisasterDatabaseWebsite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "users",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "science_essay",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    fb_time = table.Column<DateTime>(nullable: false),
                    wz_content = table.Column<string>(nullable: true),
                    wz_img = table.Column<string>(nullable: true),
                    wz_style = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    userID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_science_essay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_science_essay_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "forum_msg",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comment = table.Column<string>(nullable: true),
                    comment_time = table.Column<DateTime>(nullable: false),
                    userID = table.Column<int>(nullable: false),
                    essayID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forum_msg", x => x.ID);
                    table.ForeignKey(
                        name: "FK_forum_msg_science_essay_essayID",
                        column: x => x.essayID,
                        principalTable: "science_essay",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_forum_msg_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_forum_msg_essayID",
                table: "forum_msg",
                column: "essayID");

            migrationBuilder.CreateIndex(
                name: "IX_forum_msg_userID",
                table: "forum_msg",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_science_essay_userID",
                table: "science_essay",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "forum_msg");

            migrationBuilder.DropTable(
                name: "science_essay");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "users",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "users",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

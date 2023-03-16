using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DemoEF.Migrations
{
    /// <inheritdoc />
    public partial class TPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TPTBlogId",
                table: "BlogPost",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TPTBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPTBlogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TPTRssBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    RssUrl = table.Column<string>(type: "text", nullable: false),
                    RssCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPTRssBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPTRssBlogs_TPTBlogs_Id",
                        column: x => x.Id,
                        principalTable: "TPTBlogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPost_TPTBlogId",
                table: "BlogPost",
                column: "TPTBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPost_TPTBlogs_TPTBlogId",
                table: "BlogPost",
                column: "TPTBlogId",
                principalTable: "TPTBlogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPost_TPTBlogs_TPTBlogId",
                table: "BlogPost");

            migrationBuilder.DropTable(
                name: "TPTRssBlogs");

            migrationBuilder.DropTable(
                name: "TPTBlogs");

            migrationBuilder.DropIndex(
                name: "IX_BlogPost_TPTBlogId",
                table: "BlogPost");

            migrationBuilder.DropColumn(
                name: "TPTBlogId",
                table: "BlogPost");
        }
    }
}

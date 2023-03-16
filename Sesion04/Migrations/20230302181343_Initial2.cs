using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_OriginalBlogId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_OriginalBlogId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "OriginalBlogId",
                table: "Posts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalBlogId",
                table: "Posts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_OriginalBlogId",
                table: "Posts",
                column: "OriginalBlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_OriginalBlogId",
                table: "Posts",
                column: "OriginalBlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

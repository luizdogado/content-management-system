using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ContentPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContentPage",
                table: "ContentPage");

            migrationBuilder.RenameTable(
                name: "ContentPage",
                newName: "HtmlContentContentPage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HtmlContentContentPage",
                table: "HtmlContentContentPage",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HtmlContentContentPage",
                table: "HtmlContentContentPage");

            migrationBuilder.RenameTable(
                name: "HtmlContentContentPage",
                newName: "ContentPage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContentPage",
                table: "ContentPage",
                column: "Id");
        }
    }
}

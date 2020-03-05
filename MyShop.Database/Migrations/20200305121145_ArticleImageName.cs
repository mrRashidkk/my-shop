using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Database.Migrations
{
    public partial class ArticleImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Articles",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Articles",
                newName: "ImageId");
        }
    }
}

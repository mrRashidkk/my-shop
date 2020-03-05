using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Database.Migrations
{
    public partial class ArticleImageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Articles");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Articles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "Image",
                table: "Articles",
                nullable: false,
                defaultValue: 0);
        }
    }
}

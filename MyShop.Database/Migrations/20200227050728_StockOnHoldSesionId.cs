﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Database.Migrations
{
    public partial class StockOnHoldSesionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "StocksOnHold",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "StocksOnHold");
        }
    }
}
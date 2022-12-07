﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IDS",
                table: "Transferencias",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDS",
                table: "Transferencias");
        }
    }
}

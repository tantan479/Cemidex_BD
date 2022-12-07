using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Falecidos");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Memorials",
                type: "TEXT",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Falecidos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Memorials");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Falecidos");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Falecidos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

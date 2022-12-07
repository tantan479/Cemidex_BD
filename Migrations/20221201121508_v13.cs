using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$km.aAnqQKWTxOXtPXlNfoerXK7BI0twwQ5bk4lk/21lVDr8C/6W.m");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 2,
                column: "Senha",
                value: "$2a$10$NAaw.e.vWbau.yd4Dp1QnugRkqqF65g9Vf6QI6Ka30zg52SihEk1W");
        }
    }
}

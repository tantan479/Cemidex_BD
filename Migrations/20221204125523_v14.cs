using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "IDAdministrador", "CPF", "Email", "Gerente", "Nome", "Senha", "Telefone" },
                values: new object[] { 1, "12345678910", "cachao@gmail.com", true, "Noa Cachão Quinta", "$2a$10$jE6sfEydTFc1J8de5RSSBO1QjKJHIg9Lo5SFa1e3mTJpzZZH3NvoO", "1234567891011" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "IDAdministrador", "CPF", "Email", "Gerente", "Nome", "Senha", "Telefone" },
                values: new object[] { 2, "12345678910", "cachao@gmail.com", true, "Noa Cachão Quinta", "$2a$10$km.aAnqQKWTxOXtPXlNfoerXK7BI0twwQ5bk4lk/21lVDr8C/6W.m", "1234567891011" });
        }
    }
}

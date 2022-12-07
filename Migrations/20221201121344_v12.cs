using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "IDAdministrador", "CPF", "Email", "Gerente", "Nome", "Senha", "Telefone" },
                values: new object[] { 2, "12345678910", "cachao@gmail.com", true, "Noa Cachão Quinta", "$2a$10$NAaw.e.vWbau.yd4Dp1QnugRkqqF65g9Vf6QI6Ka30zg52SihEk1W", "1234567891011" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "IDAdministrador", "CPF", "Email", "Gerente", "Nome", "Senha", "Telefone" },
                values: new object[] { 1, "12345678910", "cachao@gmail.com", true, "Noa Cachão Quinta", "$2a$10$jDwU1nmwdtASOEI3V7gZf.mTAMLa3G/3aCUGkzUmd4WHAtavky/Ji", "1234567891011" });
        }
    }
}

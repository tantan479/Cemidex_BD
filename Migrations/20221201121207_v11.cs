using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$jDwU1nmwdtASOEI3V7gZf.mTAMLa3G/3aCUGkzUmd4WHAtavky/Ji");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 1,
                column: "Senha",
                value: "$2a$10$znQuK.R3tHxmvV4Jhnny.Og47LeqCXFffmpNh1KreN809nEJB4Swq");
        }
    }
}

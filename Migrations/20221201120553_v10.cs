using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 1,
                columns: new[] { "Email", "Senha" },
                values: new object[] { "cachao@gmail.com", "$2a$10$znQuK.R3tHxmvV4Jhnny.Og47LeqCXFffmpNh1KreN809nEJB4Swq" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 1,
                columns: new[] { "Email", "Senha" },
                values: new object[] { "cachão@gmail.com", "$2a$10$dwJiSRafMmA.hwxqX6Nm/.pcj0VH6Kd8wQLgyz7qDZkazXYTwYehm" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exumacaos_Administradores_IDAdministrador",
                table: "Exumacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Administradores_IDAdm",
                table: "Transferencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores");

            migrationBuilder.RenameTable(
                name: "Administradores",
                newName: "Administrador");

            migrationBuilder.RenameColumn(
                name: "gerente",
                table: "Administrador",
                newName: "Gerente");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Administrador",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administrador",
                table: "Administrador",
                column: "IDAdministrador");

            migrationBuilder.InsertData(
                table: "Administrador",
                columns: new[] { "IDAdministrador", "CPF", "Email", "Gerente", "Nome", "Senha", "Telefone" },
                values: new object[] { 1, "12345678910", "cachão@gmail.com", true, "Noa Cachão Quinta", "$2a$10$dwJiSRafMmA.hwxqX6Nm/.pcj0VH6Kd8wQLgyz7qDZkazXYTwYehm", "1234567891011" });

            migrationBuilder.CreateIndex(
                name: "IX_Administrador_Email",
                table: "Administrador",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exumacaos_Administrador_IDAdministrador",
                table: "Exumacaos",
                column: "IDAdministrador",
                principalTable: "Administrador",
                principalColumn: "IDAdministrador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Administrador_IDAdm",
                table: "Transferencias",
                column: "IDAdm",
                principalTable: "Administrador",
                principalColumn: "IDAdministrador",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exumacaos_Administrador_IDAdministrador",
                table: "Exumacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Administrador_IDAdm",
                table: "Transferencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Administrador",
                table: "Administrador");

            migrationBuilder.DropIndex(
                name: "IX_Administrador_Email",
                table: "Administrador");

            migrationBuilder.DeleteData(
                table: "Administrador",
                keyColumn: "IDAdministrador",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Administrador");

            migrationBuilder.RenameTable(
                name: "Administrador",
                newName: "Administradores");

            migrationBuilder.RenameColumn(
                name: "Gerente",
                table: "Administradores",
                newName: "gerente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Administradores",
                table: "Administradores",
                column: "IDAdministrador");

            migrationBuilder.AddForeignKey(
                name: "FK_Exumacaos_Administradores_IDAdministrador",
                table: "Exumacaos",
                column: "IDAdministrador",
                principalTable: "Administradores",
                principalColumn: "IDAdministrador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Administradores_IDAdm",
                table: "Transferencias",
                column: "IDAdm",
                principalTable: "Administradores",
                principalColumn: "IDAdministrador",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

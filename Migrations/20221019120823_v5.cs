using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tranferencias_Administradores_IDAdm",
                table: "Tranferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Tranferencias_Jazigos_IDJazigo1",
                table: "Tranferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Tranferencias_Jazigos_IDJazigo2",
                table: "Tranferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Tranferencias_Sepultamentos_IDSepultamento",
                table: "Tranferencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tranferencias",
                table: "Tranferencias");

            migrationBuilder.RenameTable(
                name: "Tranferencias",
                newName: "Transferencias");

            migrationBuilder.RenameIndex(
                name: "IX_Tranferencias_IDSepultamento",
                table: "Transferencias",
                newName: "IX_Transferencias_IDSepultamento");

            migrationBuilder.RenameIndex(
                name: "IX_Tranferencias_IDJazigo2",
                table: "Transferencias",
                newName: "IX_Transferencias_IDJazigo2");

            migrationBuilder.RenameIndex(
                name: "IX_Tranferencias_IDJazigo1",
                table: "Transferencias",
                newName: "IX_Transferencias_IDJazigo1");

            migrationBuilder.RenameIndex(
                name: "IX_Tranferencias_IDAdm",
                table: "Transferencias",
                newName: "IX_Transferencias_IDAdm");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transferencias",
                table: "Transferencias",
                column: "IDTransferencia");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Administradores_IDAdm",
                table: "Transferencias",
                column: "IDAdm",
                principalTable: "Administradores",
                principalColumn: "IDAdministrador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Jazigos_IDJazigo1",
                table: "Transferencias",
                column: "IDJazigo1",
                principalTable: "Jazigos",
                principalColumn: "IDJazigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Jazigos_IDJazigo2",
                table: "Transferencias",
                column: "IDJazigo2",
                principalTable: "Jazigos",
                principalColumn: "IDJazigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Sepultamentos_IDSepultamento",
                table: "Transferencias",
                column: "IDSepultamento",
                principalTable: "Sepultamentos",
                principalColumn: "IDSepultamento",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Administradores_IDAdm",
                table: "Transferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Jazigos_IDJazigo1",
                table: "Transferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Jazigos_IDJazigo2",
                table: "Transferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Sepultamentos_IDSepultamento",
                table: "Transferencias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transferencias",
                table: "Transferencias");

            migrationBuilder.RenameTable(
                name: "Transferencias",
                newName: "Tranferencias");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencias_IDSepultamento",
                table: "Tranferencias",
                newName: "IX_Tranferencias_IDSepultamento");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencias_IDJazigo2",
                table: "Tranferencias",
                newName: "IX_Tranferencias_IDJazigo2");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencias_IDJazigo1",
                table: "Tranferencias",
                newName: "IX_Tranferencias_IDJazigo1");

            migrationBuilder.RenameIndex(
                name: "IX_Transferencias_IDAdm",
                table: "Tranferencias",
                newName: "IX_Tranferencias_IDAdm");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tranferencias",
                table: "Tranferencias",
                column: "IDTransferencia");

            migrationBuilder.AddForeignKey(
                name: "FK_Tranferencias_Administradores_IDAdm",
                table: "Tranferencias",
                column: "IDAdm",
                principalTable: "Administradores",
                principalColumn: "IDAdministrador",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tranferencias_Jazigos_IDJazigo1",
                table: "Tranferencias",
                column: "IDJazigo1",
                principalTable: "Jazigos",
                principalColumn: "IDJazigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tranferencias_Jazigos_IDJazigo2",
                table: "Tranferencias",
                column: "IDJazigo2",
                principalTable: "Jazigos",
                principalColumn: "IDJazigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tranferencias_Sepultamentos_IDSepultamento",
                table: "Tranferencias",
                column: "IDSepultamento",
                principalTable: "Sepultamentos",
                principalColumn: "IDSepultamento",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

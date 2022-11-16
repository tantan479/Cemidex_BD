using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cemidex_BD.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    IDAdministrador = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    gerente = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.IDAdministrador);
                });

            migrationBuilder.CreateTable(
                name: "Falecidos",
                columns: table => new
                {
                    IDFalecido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    NomeMae = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    NomePai = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    TempoEnterro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Sexo = table.Column<char>(type: "TEXT", nullable: false),
                    EstadoCivil = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    RegistroObito = table.Column<string>(type: "TEXT", nullable: false),
                    CertidaoObito = table.Column<string>(type: "TEXT", nullable: false),
                    DataObito = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Falecidos", x => x.IDFalecido);
                });

            migrationBuilder.CreateTable(
                name: "Localizacaos",
                columns: table => new
                {
                    IDLocal = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 16, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacaos", x => x.IDLocal);
                });

            migrationBuilder.CreateTable(
                name: "PlanoFunebres",
                columns: table => new
                {
                    IDPlano = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Preco = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoFunebres", x => x.IDPlano);
                });

            migrationBuilder.CreateTable(
                name: "Exumacaos",
                columns: table => new
                {
                    IDExumacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDAdministrador = table.Column<int>(type: "INTEGER", nullable: false),
                    Motivo = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exumacaos", x => x.IDExumacao);
                    table.ForeignKey(
                        name: "FK_Exumacaos_Administradores_IDAdministrador",
                        column: x => x.IDAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "IDAdministrador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memorials",
                columns: table => new
                {
                    IDMemorial = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDFalecido = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memorials", x => x.IDMemorial);
                    table.ForeignKey(
                        name: "FK_Memorials_Falecidos_IDFalecido",
                        column: x => x.IDFalecido,
                        principalTable: "Falecidos",
                        principalColumn: "IDFalecido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jazigos",
                columns: table => new
                {
                    IDJazigo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDLocal = table.Column<int>(type: "INTEGER", nullable: false),
                    NumEspacos = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jazigos", x => x.IDJazigo);
                    table.ForeignKey(
                        name: "FK_Jazigos_Localizacaos_IDLocal",
                        column: x => x.IDLocal,
                        principalTable: "Localizacaos",
                        principalColumn: "IDLocal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensalidades",
                columns: table => new
                {
                    IDMensalidade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDPlano = table.Column<int>(type: "INTEGER", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensalidades", x => x.IDMensalidade);
                    table.ForeignKey(
                        name: "FK_Mensalidades_PlanoFunebres_IDPlano",
                        column: x => x.IDPlano,
                        principalTable: "PlanoFunebres",
                        principalColumn: "IDPlano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requerentes",
                columns: table => new
                {
                    IdRequerente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 13, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    IdPlano = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requerentes", x => x.IdRequerente);
                    table.ForeignKey(
                        name: "FK_Requerentes_PlanoFunebres_IdPlano",
                        column: x => x.IdPlano,
                        principalTable: "PlanoFunebres",
                        principalColumn: "IDPlano",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sepultamentos",
                columns: table => new
                {
                    IDSepultamento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDJazigo = table.Column<int>(type: "INTEGER", nullable: false),
                    IDRequerente = table.Column<int>(type: "INTEGER", nullable: false),
                    IDFalecido = table.Column<int>(type: "INTEGER", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepultamentos", x => x.IDSepultamento);
                    table.ForeignKey(
                        name: "FK_Sepultamentos_Falecidos_IDFalecido",
                        column: x => x.IDFalecido,
                        principalTable: "Falecidos",
                        principalColumn: "IDFalecido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepultamentos_Jazigos_IDJazigo",
                        column: x => x.IDJazigo,
                        principalTable: "Jazigos",
                        principalColumn: "IDJazigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepultamentos_Requerentes_IDRequerente",
                        column: x => x.IDRequerente,
                        principalTable: "Requerentes",
                        principalColumn: "IdRequerente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    IDVenda = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDRequerente = table.Column<int>(type: "INTEGER", nullable: false),
                    IDJazigo = table.Column<int>(type: "INTEGER", nullable: false),
                    valor = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.IDVenda);
                    table.ForeignKey(
                        name: "FK_Vendas_Jazigos_IDJazigo",
                        column: x => x.IDJazigo,
                        principalTable: "Jazigos",
                        principalColumn: "IDJazigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendas_Requerentes_IDRequerente",
                        column: x => x.IDRequerente,
                        principalTable: "Requerentes",
                        principalColumn: "IdRequerente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tranferencias",
                columns: table => new
                {
                    IDTransferencia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDJazigo1 = table.Column<int>(type: "INTEGER", nullable: false),
                    IDJazigo2 = table.Column<int>(type: "INTEGER", nullable: false),
                    IDSepultamento = table.Column<int>(type: "INTEGER", nullable: false),
                    IDAdm = table.Column<int>(type: "INTEGER", nullable: false),
                    Motivo = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tranferencias", x => x.IDTransferencia);
                    table.ForeignKey(
                        name: "FK_Tranferencias_Administradores_IDAdm",
                        column: x => x.IDAdm,
                        principalTable: "Administradores",
                        principalColumn: "IDAdministrador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tranferencias_Jazigos_IDJazigo1",
                        column: x => x.IDJazigo1,
                        principalTable: "Jazigos",
                        principalColumn: "IDJazigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tranferencias_Jazigos_IDJazigo2",
                        column: x => x.IDJazigo2,
                        principalTable: "Jazigos",
                        principalColumn: "IDJazigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tranferencias_Sepultamentos_IDSepultamento",
                        column: x => x.IDSepultamento,
                        principalTable: "Sepultamentos",
                        principalColumn: "IDSepultamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anuidades",
                columns: table => new
                {
                    IDAnuidade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IDVenda = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuidades", x => x.IDAnuidade);
                    table.ForeignKey(
                        name: "FK_Anuidades_Vendas_IDVenda",
                        column: x => x.IDVenda,
                        principalTable: "Vendas",
                        principalColumn: "IDVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuidades_IDVenda",
                table: "Anuidades",
                column: "IDVenda");

            migrationBuilder.CreateIndex(
                name: "IX_Exumacaos_IDAdministrador",
                table: "Exumacaos",
                column: "IDAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Jazigos_IDLocal",
                table: "Jazigos",
                column: "IDLocal");

            migrationBuilder.CreateIndex(
                name: "IX_Memorials_IDFalecido",
                table: "Memorials",
                column: "IDFalecido");

            migrationBuilder.CreateIndex(
                name: "IX_Mensalidades_IDPlano",
                table: "Mensalidades",
                column: "IDPlano");

            migrationBuilder.CreateIndex(
                name: "IX_Requerentes_IdPlano",
                table: "Requerentes",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_Sepultamentos_IDFalecido",
                table: "Sepultamentos",
                column: "IDFalecido");

            migrationBuilder.CreateIndex(
                name: "IX_Sepultamentos_IDJazigo",
                table: "Sepultamentos",
                column: "IDJazigo");

            migrationBuilder.CreateIndex(
                name: "IX_Sepultamentos_IDRequerente",
                table: "Sepultamentos",
                column: "IDRequerente");

            migrationBuilder.CreateIndex(
                name: "IX_Tranferencias_IDAdm",
                table: "Tranferencias",
                column: "IDAdm");

            migrationBuilder.CreateIndex(
                name: "IX_Tranferencias_IDJazigo1",
                table: "Tranferencias",
                column: "IDJazigo1");

            migrationBuilder.CreateIndex(
                name: "IX_Tranferencias_IDJazigo2",
                table: "Tranferencias",
                column: "IDJazigo2");

            migrationBuilder.CreateIndex(
                name: "IX_Tranferencias_IDSepultamento",
                table: "Tranferencias",
                column: "IDSepultamento");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IDJazigo",
                table: "Vendas",
                column: "IDJazigo");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IDRequerente",
                table: "Vendas",
                column: "IDRequerente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anuidades");

            migrationBuilder.DropTable(
                name: "Exumacaos");

            migrationBuilder.DropTable(
                name: "Memorials");

            migrationBuilder.DropTable(
                name: "Mensalidades");

            migrationBuilder.DropTable(
                name: "Tranferencias");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Sepultamentos");

            migrationBuilder.DropTable(
                name: "Falecidos");

            migrationBuilder.DropTable(
                name: "Jazigos");

            migrationBuilder.DropTable(
                name: "Requerentes");

            migrationBuilder.DropTable(
                name: "Localizacaos");

            migrationBuilder.DropTable(
                name: "PlanoFunebres");
        }
    }
}

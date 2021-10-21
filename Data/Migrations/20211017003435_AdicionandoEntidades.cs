using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AdicionandoEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Usuarios",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "senha",
                table: "Usuarios",
                newName: "Senha");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuarios",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "Usuarios",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProntuarioId",
                table: "Usuarios",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReponsavelId",
                table: "Usuarios",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsavelId",
                table: "Usuarios",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DentistaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataHora = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Preco = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Usuarios_DentistaId",
                        column: x => x.DentistaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rua = table.Column<string>(type: "text", nullable: false),
                    bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true),
                    Imagens = table.Column<byte[]>(type: "bytea", nullable: false),
                    ProntuarioId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Prontuarios_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerguntaBooleana",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pergunta = table.Column<string>(type: "text", nullable: false),
                    Resposta = table.Column<bool>(type: "boolean", nullable: false),
                    ProntuarioId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerguntaBooleana", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerguntaBooleana_Prontuarios_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perguntastring",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Perunta = table.Column<string>(type: "text", nullable: false),
                    Reposta = table.Column<string>(type: "text", nullable: true),
                    ProntuarioId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntastring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntastring_Prontuarios_ProntuarioId",
                        column: x => x.ProntuarioId,
                        principalTable: "Prontuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ProntuarioId",
                table: "Usuarios",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ReponsavelId",
                table: "Usuarios",
                column: "ReponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ClienteId",
                table: "Consultas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_DentistaId",
                table: "Consultas",
                column: "DentistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ProntuarioId",
                table: "Documentos",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PerguntaBooleana_ProntuarioId",
                table: "PerguntaBooleana",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntastring_ProntuarioId",
                table: "Perguntastring",
                column: "ProntuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Prontuarios_ProntuarioId",
                table: "Usuarios",
                column: "ProntuarioId",
                principalTable: "Prontuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Usuarios_ReponsavelId",
                table: "Usuarios",
                column: "ReponsavelId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Endereco_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Prontuarios_ProntuarioId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_ReponsavelId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "PerguntaBooleana");

            migrationBuilder.DropTable(
                name: "Perguntastring");

            migrationBuilder.DropTable(
                name: "Prontuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ProntuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ReponsavelId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ReponsavelId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ResponsavelId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Usuarios",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "senha");

            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}

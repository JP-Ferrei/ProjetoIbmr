using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class adicionandoarmazemconsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Consultas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Armazems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armazems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armazems_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    Validade = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ArmmazemId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArmazemId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataDeAdicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Armazems_ArmazemId",
                        column: x => x.ArmazemId,
                        principalTable: "Armazems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cro",
                table: "Usuarios",
                column: "Cro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Armazems_EnderecoId",
                table: "Armazems",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_ArmazemId",
                table: "Produtos",
                column: "ArmazemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Armazems");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Cro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Consultas");
        }
    }
}

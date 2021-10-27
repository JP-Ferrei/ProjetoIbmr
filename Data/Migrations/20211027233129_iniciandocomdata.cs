using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class iniciandocomdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Prontuarios_ProntuarioId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Usuarios_ReponsavelId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ProntuarioId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ReponsavelId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ProntuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ReponsavelId",
                table: "Usuarios");

            migrationBuilder.InsertData(
                table: "Armazems",
                column: "Id",
                value: new Guid("8a312f2f-27b7-49de-980f-4e129faeccd6"));

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "Cpf", "DataCriacao", "DataNascimento", "Discriminator", "Email", "EnderecoId", "Nome", "Senha", "Telefone", "TipoId" },
                values: new object[] { new Guid("baf6a601-e8a8-4ef0-9c24-054fffb6e905"), true, "111.111.111-12", new DateTime(2021, 10, 27, 20, 31, 28, 800, DateTimeKind.Local).AddTicks(3286), new DateTime(2021, 10, 27, 20, 31, 28, 801, DateTimeKind.Local).AddTicks(6382), "Usuario", "Admin@admin.com", null, "Admin", "AQAAAAEAACcQAAAAEADhHTjZkX8cep+3TMGUDUM4yk8I+9S+2eu4WFKadW8X6iis4RqJ4Dw4Ob/fZUr3pQ==", "12121231231", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Armazems",
                keyColumn: "Id",
                keyValue: new Guid("de42b1d6-432e-4115-b1dd-2a8dbdd6f83f"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("baf6a601-e8a8-4ef0-9c24-054fffb6e905"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ProntuarioId",
                table: "Usuarios",
                column: "ProntuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ReponsavelId",
                table: "Usuarios",
                column: "ReponsavelId");

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
    }
}

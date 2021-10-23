using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class alterandoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Armazems_ArmazemId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ArmmazemId",
                table: "Produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArmazemId",
                table: "Produtos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios",
                column: "Cpf",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Armazems_ArmazemId",
                table: "Produtos",
                column: "ArmazemId",
                principalTable: "Armazems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Armazems_ArmazemId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Cpf",
                table: "Usuarios");

            migrationBuilder.AlterColumn<Guid>(
                name: "ArmazemId",
                table: "Produtos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ArmmazemId",
                table: "Produtos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Armazems_ArmazemId",
                table: "Produtos",
                column: "ArmazemId",
                principalTable: "Armazems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

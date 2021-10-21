using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class refatorando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Usuarios",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "Id", "Nome", "Role" },
                values: new object[,]
                {
                    { 1, "Administrativo", "Admin" },
                    { 2, "Dentista", "Dentista" },
                    { 3, "Cliente", "Cliente" },
                    { 4, "Recepcionista", "Recepcionista" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoId",
                table: "Usuarios",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoUsuario_TipoId",
                table: "Usuarios",
                column: "TipoId",
                principalTable: "TipoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuario_TipoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabeleleilaLeila.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "VARCHAR(80)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    celular = table.Column<string>(type: "VARCHAR(13)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo = table.Column<int>(type: "INT", nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_cadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "agendamento",
                columns: table => new
                {
                    id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    id_usuario = table.Column<long>(type: "BIGINT", nullable: false),
                    data_hora = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    servico = table.Column<int>(type: "INT", nullable: false),
                    status = table.Column<int>(type: "INT", nullable: false),
                    observacao = table.Column<string>(type: "VARCHAR(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    data_cadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    data_alteracao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamento", x => x.id);
                    table.ForeignKey(
                        name: "FK_agendamento_usuario_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "id", "data_alteracao", "data_cadastro", "email", "celular", "nome", "senha", "tipo" },
                values: new object[] { 1L, null, new DateTime(2024, 9, 17, 13, 45, 9, 512, DateTimeKind.Local).AddTicks(5965), "cabeleleiladesin@outlook.com", "5514991234567", "Leila", "1234", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_agendamento_id_usuario",
                table: "agendamento",
                column: "id_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamento");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}

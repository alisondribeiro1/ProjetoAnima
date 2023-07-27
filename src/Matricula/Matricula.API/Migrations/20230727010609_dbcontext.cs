using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Matricula.API.Migrations
{
    /// <inheritdoc />
    public partial class dbcontext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    idMatricula = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idusuario = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    idCurso = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    aprovado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula", x => x.idMatricula);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matricula");
        }
    }
}

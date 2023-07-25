using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Boleto.API.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "boleto",
                columns: table => new
                {
                    idboleto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idmatricula = table.Column<int>(type: "integer", nullable: false),
                    valor = table.Column<decimal>(type: "numeric", nullable: false),
                    mesreferencia = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datageracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    datavencimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    pago = table.Column<bool>(type: "boolean", nullable: false),
                    urlboleto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boleto", x => x.idboleto);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boleto");
        }
    }
}

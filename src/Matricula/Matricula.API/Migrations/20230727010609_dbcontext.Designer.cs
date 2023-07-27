﻿// <auto-generated />
using Matricula.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Matricula.API.Migrations
{
    [DbContext(typeof(MatriculaDbContext))]
    [Migration("20230727010609_dbcontext")]
    partial class dbcontext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Matricula.Domain.Models.MatriculaModel", b =>
                {
                    b.Property<int>("IdMatricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idMatricula");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMatricula"));

                    b.Property<bool>("Aprovado")
                        .HasColumnType("boolean")
                        .HasColumnName("aprovado");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<int>("IdCurso")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("idCurso");

                    b.Property<int>("IdUsuario")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("idusuario");

                    b.HasKey("IdMatricula");

                    b.ToTable("matricula", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
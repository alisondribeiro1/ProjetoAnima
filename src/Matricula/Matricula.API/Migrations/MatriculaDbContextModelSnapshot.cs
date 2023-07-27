﻿// <auto-generated />
using System;
using Matricula.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Matricula.API.Migrations
{
    [DbContext(typeof(MatriculaDbContext))]
    partial class MatriculaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Nota.Domain.Models.NotaModel", b =>
                {
                    b.Property<int>("IdNota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idNota");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdNota"));

                    b.Property<int>("IdMatricula")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("idMatricula");

                    b.Property<int?>("Media")
                        .HasColumnType("integer")
                        .HasColumnName("media");

                    b.Property<int?>("Nota1")
                        .HasColumnType("integer")
                        .HasColumnName("nota1");

                    b.Property<int?>("Nota2")
                        .HasColumnType("integer")
                        .HasColumnName("nota2");

                    b.Property<int?>("Nota3")
                        .HasColumnType("integer")
                        .HasColumnName("nota3");

                    b.HasKey("IdNota");

                    b.ToTable("nota", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

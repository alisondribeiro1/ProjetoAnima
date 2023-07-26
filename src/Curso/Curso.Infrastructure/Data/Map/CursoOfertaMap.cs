using Curso.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Data.Map
{
    public class CursoOfertaMap : IEntityTypeConfiguration<CursoOfertaModel>
    {
        public void Configure(EntityTypeBuilder<CursoOfertaModel> builder)
        {
            builder.ToTable("curso_oferta"); // Nome da tabela sem aspas

            builder.HasKey(x => x.IdCursoOferta);

            builder.Property(x => x.IdCursoOferta)
                .HasColumnName("id_curso_oferta")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.IdCurso)
                .HasColumnName("id_curso")
                .IsRequired();

            builder.Property(x => x.IdTurno)
               .HasColumnName("id_turno")
               .IsRequired();

            builder.Property(x => x.IdCategoria)
                .HasColumnName("id_categoria")
                .IsRequired();

            builder.Property(x => x.IdModelo)
                .HasColumnName("id_modelo")
                .IsRequired();

            // Configura relacionamentos (chaves estrangeiras)
            builder.HasOne(x => x.Curso)
                .WithMany()
                .HasForeignKey(x => x.IdCurso)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Turno)
                .WithMany()
                .HasForeignKey(x => x.IdTurno)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Categoria)
                .WithMany()
                .HasForeignKey(x => x.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Modelo)
                .WithMany()
                .HasForeignKey(x => x.IdModelo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

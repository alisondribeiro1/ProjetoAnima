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
    public class CursoMap : IEntityTypeConfiguration<CursoModel>
    {
        public void Configure(EntityTypeBuilder<CursoModel> builder)
        {
            builder.ToTable("curso"); //Nome da tabela sem aspas

            builder.HasKey(x => x.idCurso);

            builder.Property(x => x.idCurso)
                .HasColumnName("id_curso")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao")
                .IsRequired();

            builder.Property(x => x.CargaHoraria)
                .HasColumnName("carga_horaria")
                .IsRequired();

        }
    }
}

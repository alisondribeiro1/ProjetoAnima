using Cursos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cursos.Context.Map
{
    public class CursoMap : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("curso");// Especifica o nome da tabela sem aspas
            builder.HasKey(x => x.IdCurso);
            builder.Property(x => x.IdCurso).HasColumnName("idcurso").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200).HasColumnName("nome");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("text").HasColumnName("descricao");
            builder.Property(x => x.Modelo).IsRequired().HasColumnName("modelo");
            builder.Property(x => x.CargaHoraria).IsRequired().HasColumnName("cargahoraria");
            builder.Property(x => x.Categoria).IsRequired().HasColumnName("categoria");
            builder.Property(x => x.Turno).IsRequired().HasColumnName("turno");
        }
    }
}

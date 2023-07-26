using Matricula.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Matricula.Infrastructure.Data.Map
{
    internal class MatriculaMap : IEntityTypeConfiguration<MatriculaModel>
    {
        public void Configure(EntityTypeBuilder<MatriculaModel> builder)
        {
            builder.ToTable("matricula");// Especifica o nome da tabela sem aspas

            builder.HasKey(x => x.IdMatricula);

            builder.Property(x => x.IdMatricula)
                   .HasColumnName("Idmatricula") // Especifica o nome da coluna sem aspas
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.IdCurso)
                   .HasColumnName("idCurso")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.IdUsuario)
                   .HasColumnName("idusuario")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Ativo)
                   .HasColumnName("ativo")
                   .IsRequired();

            builder.Property(x => x.Aprovado)
                   .HasColumnName("aprovado")
                   .IsRequired();
    }
    }
}

using Matricula.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nota.Domain.Models;

namespace Nota.Infrastructure.Data.Map
{
    internal class NotaMap : IEntityTypeConfiguration<NotaModel>
    {
        public void Configure(EntityTypeBuilder<NotaModel> builder)
        {
            builder.ToTable("nota");// Especifica o nome da tabela sem aspas

            builder.HasKey(x => x.IdNota);

            builder.Property(x => x.IdNota)
                   .HasColumnName("idNota") // Especifica o nome da coluna sem aspas
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.IdMatricula)
                   .HasColumnName("idMatricula")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Nota1)
                   .HasColumnName("nota1");

            builder.Property(x => x.Nota2)
                   .HasColumnName("nota2");

            builder.Property(x => x.Nota3)
                   .HasColumnName("nota3");
       
            builder.Property(x => x.Media)
                   .HasColumnName("media");
       }  
    }
}

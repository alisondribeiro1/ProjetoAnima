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
    public class CategoriaMap : IEntityTypeConfiguration<CategoriaModel>
    {
        public void Configure(EntityTypeBuilder<CategoriaModel> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(x => x.IdCategoria);

            builder.Property(x => x.IdCategoria)
                .HasColumnName("id_categoria")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .IsRequired();
        }
    }
}

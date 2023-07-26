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
    public class ModeloMap : IEntityTypeConfiguration<ModeloModel>
    {
        public void Configure(EntityTypeBuilder<ModeloModel> builder)
        {
            builder.ToTable("modelo");

            builder.HasKey(x => x.IdModelo);

            builder.Property(x => x.IdModelo)
                .HasColumnName("id_modelo")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .IsRequired();
        }
    }
}

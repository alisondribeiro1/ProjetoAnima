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
    public class TurnoMap : IEntityTypeConfiguration<TurnoModel>
    {
        public void Configure(EntityTypeBuilder<TurnoModel> builder)
        {
            builder.ToTable("turno");

            builder.HasKey(x => x.IdTurno);

            builder.Property(x => x.IdTurno)
                .HasColumnName("id_turno")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .IsRequired();
        }
    }
}

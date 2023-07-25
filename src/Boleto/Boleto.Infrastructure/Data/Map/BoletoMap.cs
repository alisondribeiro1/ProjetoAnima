using Boleto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boleto.Infrastructure.Data.Map
{
    internal class BoletoMap : IEntityTypeConfiguration<BoletoModel>
    {
        public void Configure(EntityTypeBuilder<BoletoModel> builder)
        {
            builder.ToTable("boleto");

            builder.HasKey(x => x.IdBoleto);

            builder.Property(x => x.IdBoleto)
                   .HasColumnName("idboleto")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.IdMatricula)
                   .HasColumnName("idmatricula")
                   .IsRequired();

            builder.Property(x => x.Valor)
                   .HasColumnName("valor")
                   .IsRequired();

            builder.Property(x => x.MesReferencia)
                   .HasColumnName("mesreferencia")
                   .IsRequired();

            builder.Property(x => x.DataGeracao)
                   .HasColumnName("datageracao")
                   .IsRequired();

            builder.Property(x => x.DataVencimento)
                   .HasColumnName("datavencimento")
                   .IsRequired();

            builder.Property(x => x.Pago)
                   .HasColumnName("pago")
                   .IsRequired();

            builder.Property(x => x.UrlBoleto)
                   .HasColumnName("urlboleto")
                   .IsRequired();
        }
    }
}

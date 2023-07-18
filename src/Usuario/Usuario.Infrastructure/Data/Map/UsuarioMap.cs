using Usuario.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Usuario.Infrastructure.Data.Map
{
    internal class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("usuario");// Especifica o nome da tabela sem aspas

            builder.HasKey(x => x.IdUsuario);

            builder.Property(x => x.IdUsuario)
                   .HasColumnName("idusuario") // Especifica o nome da coluna sem aspas
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                   .HasColumnName("nome")
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(x => x.Login)
                   .HasColumnName("login")
                   .IsRequired()
                   .HasMaxLength(50);
        
            builder.Property(x => x.Senha)
                   .HasColumnName("senha")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Email)
                   .HasColumnName("email")
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Celular)
                   .HasColumnName("celular")
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.CPF)
                   .HasColumnName("cpf")
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.DataNascimento)
                   .HasColumnName("datanascimento")
                   .IsRequired();

            builder.Property(x => x.Administrador)
                   .HasColumnName("administrador")
                   .IsRequired();
    }
    }
}

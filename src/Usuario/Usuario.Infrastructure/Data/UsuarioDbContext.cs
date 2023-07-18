using Microsoft.EntityFrameworkCore;
using Usuario.Domain.Models;
using Usuario.Infrastructure.Data.Map;

namespace Usuario.Infrastructure.Data
{
    public class UsuarioDbContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo, como chaves primárias, índices, relações, etc.
            // Exemplo: modelBuilder.Entity<Usuario>().HasKey(a => a.Id);
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

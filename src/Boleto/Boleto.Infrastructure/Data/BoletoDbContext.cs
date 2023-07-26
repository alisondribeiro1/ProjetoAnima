using Microsoft.EntityFrameworkCore;
using Boleto.Domain.Models;
using Boleto.Infrastructure.Data.Map;

namespace Boleto.Infrastructure.Data
{
    public class BoletoDbContext : DbContext
    {
        public DbSet<BoletoModel> Boletos { get; set; }

        public BoletoDbContext(DbContextOptions<BoletoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo, como chaves primárias, índices, relações, etc.
            // Exemplo: modelBuilder.Entity<Boleto>().HasKey(a => a.Id);
            modelBuilder.ApplyConfiguration(new BoletoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

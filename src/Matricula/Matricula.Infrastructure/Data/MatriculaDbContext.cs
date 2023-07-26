using Microsoft.EntityFrameworkCore;
using Matricula.Domain.Models;
using Matricula.Infrastructure.Data.Map;

namespace Matricula.Infrastructure.Data
{
    public class MatriculaDbContext : DbContext
    {
        public DbSet<MatriculaModel> Matriculas { get; set; }

        public MatriculaDbContext(DbContextOptions<MatriculaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo, como chaves primárias, índices, relações, etc.
            // Exemplo: modelBuilder.Entity<Matricula>().HasKey(a => a.Id);
            modelBuilder.ApplyConfiguration(new MatriculaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
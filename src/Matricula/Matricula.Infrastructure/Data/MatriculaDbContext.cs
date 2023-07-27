using Microsoft.EntityFrameworkCore;
using Matricula.Domain.Models;
using Nota.Domain.Models;
using Matricula.Infrastructure.Data.Map;
using Nota.Infrastructure.Data.Map;

namespace Matricula.Infrastructure.Data
{
    public class MatriculaDbContext : DbContext
    {
        public DbSet<MatriculaModel> Matriculas { get; set; }
        public DbSet<NotaModel> Notas { get; set; }

        public MatriculaDbContext(DbContextOptions<MatriculaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo, como chaves primárias, índices, relações, etc.
            // Exemplo: modelBuilder.Entity<Matricula>().HasKey(a => a.Id);
            modelBuilder.ApplyConfiguration(new MatriculaMap());
            modelBuilder.ApplyConfiguration(new NotaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
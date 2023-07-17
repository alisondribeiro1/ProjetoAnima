using Microsoft.EntityFrameworkCore;
using Aluno.Domain.Models;
using Aluno.Infrastructure.Data.Map;

namespace Aluno.Infrastructure.Data
{
    public class AlunoDbContext : DbContext
    {
        public DbSet<AlunoModel> Alunos { get; set; }

        public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais do modelo, como chaves primárias, índices, relações, etc.
            // Exemplo: modelBuilder.Entity<Aluno>().HasKey(a => a.Id);
            modelBuilder.ApplyConfiguration(new AlunoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
